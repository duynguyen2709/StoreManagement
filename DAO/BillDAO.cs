using StoreManagement.Entities;
using System;
using System.Collections.Generic;
using StoreManagement.Utilities;

namespace StoreManagement.DAO
{
    internal class BillDAO : BaseDAO
    {
        public override Object get(int ID, Type type = null)
        {
            try
            {
                using (var context = new StoreManagementEntities())
                {
                    foreach (var bill in context.BillHistories)
                    {
                        if (bill.BillID == ID)
                        {
                            Dictionary<int, int> lstProduct = new Dictionary<int, int>();

                            foreach (var billDetail in context.BillDetails)
                            {
                                if (billDetail.BillID == ID)
                                {
                                    lstProduct.Add(billDetail.ProductID, billDetail.Quantity);
                                }
                            }

                            Object obj = new
                            {
                                BillInfo = bill,
                                ListProduct = lstProduct
                            };

                            BillEntity entity = convertToEntity(obj) as BillEntity;

                            return entity;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new CustomException(this.GetType() + " : Get Entity");
            }

            return null;
        }

        public override Object getAll(Type type = null)
        {
            List<BillEntity> listBillEntities = new List<BillEntity>();

            using (var context = new StoreManagementEntities())
            {
                foreach (var bill in context.BillHistories)
                {
                    Dictionary<int, int> lstProduct = new Dictionary<int, int>();
                    foreach (var billDetail in context.BillDetails)
                    {
                        if (billDetail.BillID == bill.BillID)
                        {
                            lstProduct.Add(billDetail.ProductID, billDetail.Quantity);
                        }
                    }

                    Object obj = new
                    {
                        BillInfo = bill,
                        ListProduct = lstProduct
                    };

                    BillEntity entity = convertToEntity(obj) as BillEntity;
                    listBillEntities.Add(entity);
                }
            }

            return listBillEntities;
        }

        public override void insert(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Inserting Null Value");

            BillEntity newBill = obj as BillEntity;

            BillHistory billHistory = new BillHistory();
            billHistory.BillID = newBill.BillID;
            billHistory.BillDate = newBill.BillDate;
            billHistory.TotalPrice = CalculateTotalPrice(newBill.ListProduct);

            using (var context = new StoreManagementEntities())
            {
                context.BillHistories.Add(billHistory);
                int id = billHistory.BillID;

                foreach (KeyValuePair<int, int> product in newBill.ListProduct)
                {
                    BillDetail billDetail = new BillDetail();
                    billDetail.ProductID = product.Key;
                    billDetail.Quantity = product.Value;
                    context.BillDetails.Add(billDetail);
                }
                context.SaveChanges();
            }
        }

        protected override Object convertToEntity(Object obj)
        {
            if (obj == null)
                throw new CustomException(this.GetType() + " : Converting to Entity Null Value");

            Dictionary<int, int> listProduct =
                obj?.GetType().GetProperty("ListProduct")?.GetValue(obj, null) as Dictionary<int, int>;
            BillHistory billInfo = obj?.GetType().GetProperty("BillInfo")?.GetValue(obj, null) as BillHistory;

            BillEntity entity = new BillEntity()
            {
                BillID = billInfo.BillID,
                BillDate = billInfo.BillDate,
                ListProduct = listProduct,
                TotalPrice = CalculateTotalPrice(listProduct)
            };

            return entity;
        }

        private long CalculateTotalPrice(Dictionary<int, int> listProduct)
        {
            long sum = 0;
            ProductDAO dao = new ProductDAO();

            foreach (KeyValuePair<int, int> product in listProduct)
            {
                ProductEntity entity = dao.get(product.Key) as ProductEntity;
                sum += entity.Price * product.Value;
            }

            return sum;
        }
    }
}