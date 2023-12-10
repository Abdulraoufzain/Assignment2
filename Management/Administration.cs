using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    //هذا الكلاس يحتوي على دوال الاضافة والعديل والحذف 
    public class Administration
    {
        private readonly ManagementDbContext Context;

        public Administration()
        {
            Context = new ManagementDbContext();
            Context.Database.Migrate();
        }

        // إضافة سيارة جديدة إلى قاعدة البيانات
        public void AddCar(Car car)
        {
            Context.Cars.Add(car);
            Context.SaveChanges();
        }

        // إضافة قطعة غيار جديدة إلى قاعدة البيانات
        public void AddPart(Part part)
        {
            Context.Parts.Add(part);
            Context.SaveChanges();
        }

        // إضافة مورد جديد إلى قاعدة البيانات
        public void AddSupplier(Supplier supplier)
        {
            Context.Suppliers.Add(supplier);
            Context.SaveChanges();
        }

        // إضافة عملية بيع جديدة إلى قاعدة البيانات
        public void AddSale(Sale sale)
        {
            Context.Sales.Add(sale);
            Context.SaveChanges();
        }

        // إضافة عميل جديد إلى قاعدة البيانات
        public void AddCustomer(Customer customer)
        {
            Context.Customers.Add(customer);
            Context.SaveChanges();
        }

        // الحصول على قائمة بجميع السيارات الموجودة في قاعدة البيانات
        public List<Car> GetAllCars()
        {
            return Context.Cars.ToList();
        }

        // الحصول على قائمة بجميع قطع الغيار الموجودة في قاعدة البيانات
        public List<Part> GetAllParts()
        {
            return Context.Parts.ToList();
        }

        // الحصول على قائمة بجميع الموردين الموجودين في قاعدة البيانات
        public List<Supplier> GetAllSuppliers()
        {
            return Context.Suppliers.ToList();
        }

        // الحصول على قائمة بجميع عمليات البيع الموجودة في قاعدة البيانات
        public List<Sale> GetAllSales()
        {
            return Context.Sales.ToList();
        }

        // الحصول على قائمة بجميع العملاء الموجودين في قاعدة البيانات
        public List<Customer> GetAllCustomers()
        {
            return Context.Customers.ToList();
        }

        // الحصول على سيارة بناءً على معرفها
        public Car GetCarById(int carId)
        {
            return Context.Cars.Find(carId);
        }

        // الحصول على قطعة غيار بناءً على معرفها
        public Part GetPartById(int partId)
        {
            return Context.Parts.Find(partId);
        }

        // الحصول على مورد بناءً على معرفه
        public Supplier GetSupplierById(int supplierId)
        {
            return Context.Suppliers.Find(supplierId);
        }

        // الحصول على عملية بيع بناءً على معرفها
        public Sale GetSaleById(int saleId)
        {
            return Context.Sales.Find(saleId);
        }

        // الحصول على عميل بناءً على معرفه
        public Customer GetCustomerById(int customerId)
        {
            return Context.Customers.Find(customerId);
        }

        // تحديث بيانات سيارة موجودة في قاعدة البيانات
        public void UpdateCar(Car car)
        {
            Context.Entry(car).State = EntityState.Modified;
            Context.SaveChanges();
        }

        // تحديث بيانات قطعة غيار موجودة في قاعدة البيانات
        public void UpdatePart(Part part)
        {
            Context.Entry(part).State = EntityState.Modified;
            Context.SaveChanges();
        }

        // تحديث بيانات مورد موجود في قاعدة البيانات
        public void UpdateSupplier(Supplier supplier)
        {
            Context.Entry(supplier).State = EntityState.Modified;
            Context.SaveChanges();
        }

        // تحديث بيانات عملية بيع موجودة في قاعدة البيانات
        public void UpdateSale(Sale sale)
        {
            Context.Entry(sale).State = EntityState.Modified;
            Context.SaveChanges();
        }

        // تحديث بيانات عميل موجود في قاعدة البيانات
        public void UpdateCustomer(Customer customer)
        {
            Context.Entry(customer).State = EntityState.Modified;
            Context.SaveChanges();
        }

        // حذف سيارة من قاعدة البيانات بناءً على معرفها
        public void DeleteCar(int carId)
        {
            var car = Context.Cars.Find(carId);
            if (car != null)
            {
                Context.Cars.Remove(car);
                Context.SaveChanges();
            }
        }

        // حذف قطعة غيار من قاعدة البيانات بناءً على معرفها
        public void DeletePart(int partId)
        {
            var part = Context.Parts.Find(partId);
            if (part != null)
            {
                Context.Parts.Remove(part);
                Context.SaveChanges();
            }
        }

        // حذف مورد من قاعدة البيانات بناءً على معرفه
        public void DeleteSupplier(int supplierId)
        {
            var supplier = Context.Suppliers.Find(supplierId);
            if (supplier != null)
            {
                Context.Suppliers.Remove(supplier);
                Context.SaveChanges();
            }
        }

        // حذف عملية بيع من قاعدة البيانات بناءً على معرفها
        public void DeleteSale(int saleId)
        {
            var sale = Context.Sales.Find(saleId);
            if (sale != null)
            {
                Context.Sales.Remove(sale);
                Context.SaveChanges();
            }
        }

        // حذف عميل من قاعدة البيانات بناءً على معرفه
        public void DeleteCustomer(int customerId)
        {
            var customer = Context.Customers.Find(customerId);
            if (customer != null)
            {
                Context.Customers.Remove(customer);
                Context.SaveChanges();
            }
        }
    }
}
