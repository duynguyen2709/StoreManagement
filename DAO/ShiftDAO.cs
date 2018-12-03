using StoreManagement.Entities;
using StoreManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.DAO
{
    internal class ShiftDAO : BaseDAO
    {
        public override void delete(object obj)
        {
            try
            {
                UserShiftEntity entity = obj as UserShiftEntity;

                using (var context = new StoreManagementEntities())
                {
                    var delete = (from u in context.ShiftRegistrations
                                  where entity.Week == u.Week && entity.Shift == u.Shift
                                        && entity.WeekDay == u.WeekDay
                                  select u).Single();

                    context.ShiftRegistrations.Remove(delete);

                    var shift = context.ShiftTimes.Find(entity.WeekDay, entity.Shift);
                    shift.Status = 1;

                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : Delete " + obj.ToString() + "\n" + e.Message);
                ex.showPopupError();
            }
        }

        public override object get(object ID, Type type = null)
        {
            UserShiftEntity entity = null;

            try
            {
                int Week = (int)ID?.GetType().GetProperty("Week")?.GetValue(ID, null);
                int WeekDay = (int)ID?.GetType().GetProperty("WeekDay")?.GetValue(ID, null);
                int Shift = (int)ID?.GetType().GetProperty("Shift")?.GetValue(ID, null);

                using (var context = new StoreManagementEntities())
                {
                    entity = context.ShiftRegistrations.Find(Week, WeekDay, Shift).Cast<UserShiftEntity>();
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : Get " + ID + "\n" + e.Message);
                ex.showPopupError();
            }

            return entity;
        }

        public override object getAll(Type type = null)
        {
            List<UserShiftEntity> listShift = new List<UserShiftEntity>();

            try
            {
                using (var context = new StoreManagementEntities())
                {
                    foreach (var shift in context.ShiftRegistrations)
                    {
                        UserShiftEntity entity = shift.Cast<UserShiftEntity>();
                        listShift.Add(entity);
                    }
                }
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : GetAll \n" + e.Message);
                ex.showPopupError();
            }

            return listShift;
        }

        public override int insert(object obj)
        {
            try
            {
                var newUserShift = obj as UserShiftEntity;
                ShiftRegistration shift = newUserShift.Cast<ShiftRegistration>();

                using (var context = new StoreManagementEntities())
                {
                    context.ShiftRegistrations.Add(shift);

                    var regShift = context.ShiftTimes.Find(shift.WeekDay, shift.Shift);
                    regShift.Status = 0;

                    context.SaveChanges();
                }

                return shift.Week;
            }
            catch (Exception e)
            {
                CustomException ex = new CustomException(this.GetType().Name + " : Insert " + obj.ToString() + "\n" + e.Message);
                ex.showPopupError();
            }

            return -1;
        }

        public override void update(object obj)
        {
            throw new CustomException(this.GetType().Name + ": Not support update");
        }
    }
}