﻿using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class BillDAO : BaseDAO
    {
        public override void delete(Object obj)
        {
            try
            {
                BillEntity entity = obj as BillEntity;

                using (var context = new StoreManagementEntities())
                {
                    foreach (KeyValuePair<int, int> product in entity.ListProduct)
                    {
                        var detail = (from bill in context.BillDetails
                                      where bill.BillID == entity.BillID
                                         && bill.ProductID == product.Key
                                      select bill)
                            .Single();

                        context.BillDetails.Remove(detail);
                    }

                    var history = (from bill in context.BillHistories
                                   where bill.BillID == entity.BillID
                                   select bill)
                        .Single();

                    context.BillHistories.Remove(history);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : Delete " + obj.ToString();

                throw new CustomException(msg);
            }
        }

        public override Object get(int ID, Type type = null)
        {
            try
            {
                using (var context = new StoreManagementEntities())
                {
                    var bill = context.BillHistories.Find(ID);
                    if (bill == null)
                        throw new Exception();

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
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : Get " + ID;

                throw new CustomException(msg);
            }
        }

        public override Object getAll(Type type = null)
        {
            List<BillEntity> listBillEntities = new List<BillEntity>();

            try
            {
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
            }
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : GetAll ";

                throw new CustomException(msg);
            }

            return listBillEntities;
        }

        public override int insert(Object obj)
        {
            try
            {
                if (obj == null)
                    throw new CustomException(this.GetType() + " : Inserting Null Value");

                BillEntity newBill = obj as BillEntity;

                BillHistory billHistory = new BillHistory
                {
                    CashierID = newBill.CashierID,
                    BillDate = newBill.BillDate,
                    TotalPrice = CalculateTotalPrice(newBill.ListProduct)
                };

                using (var context = new StoreManagementEntities())
                {
                    context.BillHistories.Add(billHistory);

                    foreach (KeyValuePair<int, int> product in newBill.ListProduct)
                    {
                        BillDetail billDetail = new BillDetail
                        {
                            BillID = billHistory.BillID,
                            ProductID = product.Key,
                            Quantity = product.Value
                        };

                        context.BillDetails.Add(billDetail);
                    }

                    context.SaveChanges();
                }

                return billHistory.BillID;
            }
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : Insert " + obj.ToString();

                throw new CustomException(msg);
            }
        }

        public override void update(object obj)
        {
            try
            {
                BillEntity entity = obj as BillEntity;

                using (var context = new StoreManagementEntities())
                {
                    BillHistory billHistory = context.BillHistories.Find(entity.BillID);
                    context.Entry(billHistory).CurrentValues.SetValues(entity);

                    Dictionary<int, int> listProduct = entity.ListProduct;

                    foreach (KeyValuePair<int, int> product in listProduct)
                    {
                        BillDetail billDetail = context.BillDetails.Find(entity.BillID, product.Key);

                        if (billDetail != null && billDetail.Quantity != product.Value)
                        {
                            context.Entry(billDetail)
                                   .CurrentValues.SetValues(new
                                   {
                                       BillID = billDetail.BillID,
                                       ProductID = product.Key,
                                       Quantity = product.Value
                                   });
                        }
                        else if (billDetail == null)
                        {
                            BillDetail detail = new BillDetail()
                            {
                                BillID = entity.BillID,
                                ProductID = product.Key,
                                Quantity = product.Value
                            };

                            context.BillDetails.Add(detail);
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                String msg = "";

                if (e is SqlException)
                    msg = e.InnerException.Message;
                else
                    msg = this.GetType() + " : Update " + obj.ToString();

                throw new CustomException(msg);
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
                CashierID = billInfo.CashierID,
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
                if (dao.get(product.Key) is ProductEntity entity)
                    sum += entity.Price * product.Value;
            }

            return sum;
        }
    }
}