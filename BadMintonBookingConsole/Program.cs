using BadMintonBookingBusiness;
using BadMintonBookingBusiness.Categoryy;
using BadMintonData.Models;



ICustomerBusiness cus = new CustomerBusiness();

var list = await cus.GetAll();
/*var db = new NET1702_PRN221_BadMintonContext();
var l = db.Customers.ToList();*/
Console.WriteLine(list.ToString());
