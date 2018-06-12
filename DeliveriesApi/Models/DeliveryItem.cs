using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class DeliveryItem
    {
        /*
        MySort
        Finishtime  //עמודה מחושבת  הפרש בין עכשיו ל Finishtime
        DeliveryTime // שעה
        CustomerName // שם לקוח
        CompanyNameLet // ממקום
        MyOut    //כתובת מוצא
        cityName1 // עיר
        archOut  // אזור מוצא
        mysort2 // לעדכון
        CompanyNameGet  //למקום
        Mydes // כתובת יעד
        cityName // עיר יעד
        archDes // אזור יעד
        employeeID  //אוסף *
        employeeIDsec //מוסר    *
        DeliveryStatus     // סטטוס *
        FinishTime // שעת סיום
        UrgencysName // דחיפות
        Govayna //גוביינא
        /////////////
        CustomerDeliveryNo  //מס הזמנה
        Barcode //ברקוד
        Comment // הערות
        ContactManName // שם מזמין
        UserName    //שם משתמש
        WhereToWhere  //סוג שליחות
         //1;שליחות;2;איסוף;3;העברה

        VehicleTypeID   //אמצעי הובלה
        EmployeeID_Third //שליח שלישי
        DeliveyOut  //מספר קבלן
        Receiver //שם מקבל
        DeliveryDate    //תאריך
        tehumDate //תואם בתאריך
        /////////////////
        InvoiceNum  //מס חשבונית
        PakageNum //מס חבילות
        BoxNum  //מס קרטונים
        Waiting //המתנה
        CustomerID
        */

        public int MySort { get; set; }
        public DateTime FinishtimeSenc { get; set; }  //עמודה מחושבת  הפרש בין עכשיו ל Finishtime
        public DateTime DeliveryTime { get; set; }// שעה
        public string CustomerName { get; set; }// שם לקוח
        public string CompanyNameLet { get; set; } // ממקום
        public string MyOut { get; set; }   //כתובת מוצא
        public string CityName_1 { get; set; }// עיר
        public string archOut { get; set; } // אזור מוצא
        public int mysort2 { get; set; }// לעדכון
        public string CompanyNameGet { get; set; } //למקום
        public string Mydes { get; set; } // כתובת יעד
        public string cityName { get; set; }// עיר יעד
        public string archDes { get; set; } // אזור יעד
        public int employeeID { get; set; }  //אוסף *   combo
        public int employeeIDsec { get; set; } //מוסר    * combo
        public int DeliveryStatus { get; set; }     // סטטוס * combo
        public DateTime FinishTime { get; set; }// שעת סיום
        public string UrgencysName { get; set; }// דחיפות
        public int Govayna { get; set; }//גוביינא
        /////////////
        public int CustomerDeliveryNo { get; set; } //מס הזמנה
        public string Barcode { get; set; } //ברקוד
        public string Comment { get; set; } // הערות
        public string ContactManName { get; set; } // שם מזמין
        public string UserName { get; set; }   //שם משתמש
        public int WhereToWhere { get; set; }//סוג שליחות  
        public int VehicleTypeID { get; set; }//אמצעי הובלה * combo
        public string EmployeeID_Third { get; set; }//שליח שלישי * combo employee
        public string DeliveyOut { get; set; }//מספר קבלן
        public string Receiver { get; set; }//שם מקבל
        public DateTime DeliveryDate { get; set; }   //תאריך
        public DateTime tehumDate { get; set; }//תואם בתאריך
        //InvoiceNum  //מס חשבונית
        public int PakageNum { get; set; }//מס חבילות
        public int BoxNum { get; set; } //מס קרטונים
        public int Waiting { get; set; } //המתנה
        public int CustomerID { get; set; }

        /*
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string DeliveryNote { get; set; }
        public string Description { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Combo1 { get; set; }
        public string Combo2 { get; set; }
        public string Combo3 { get; set; }
        public string Receiver1 { get; set; }
        public int Collect { get; set; }
        public DateTime Date { get; set; }
        public string ReceivedAt { get; set; }
        public string CustomerName { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Importance { get; set; }
        public string Field1 { get; set; }
        public string CourierCollected { get; set; }
        public string CourierDelivered { get; set; }
        public string Status { get; set; }
        public string EndTime { get; set; }
        */
    }
}