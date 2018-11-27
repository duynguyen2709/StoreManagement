using StoreManagement.Entities;
using System;
using System.Collections.Generic;

namespace StoreManagement.DAO
{
    internal class BillDAO : BaseDAO
    {
        public override Object get(int ID, string className = null)
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

            return null;
        }

        public override void insert(Object obj)
        {
            if (obj == null)
                throw new CustomSQLException(this.GetType() + " : Inserting Null Value");

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
                throw new CustomSQLException(this.GetType() + " : Converting to Entity Null Value");

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

            foreach (KeyValuePair<int, int> product in listProduct)
            {
                ProductEntity entity = instance.get(product.Key, "ProductEntity") as ProductEntity;
                sum += entity.Price * product.Value;
            }

            return sum;
        }
    }
}