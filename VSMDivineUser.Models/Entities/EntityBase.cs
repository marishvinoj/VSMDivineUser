using System.ComponentModel.DataAnnotations;

namespace VSMDivineUser.Models
{
    public class EntityBase
    {
        //[Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        //public int TotalCount { get; set; }
    }

//    export interface User
//    {
//        Name: string;
//        Email: string;
//        Password: string;
//        Gender: boolean;
//        MobileNumber: number;
//        EmailId: string;
//        Dob: Date;
//        Address: string;
//        Pincode?: number;
//}


//    export interface EntityBase
//    {
//        Id: number;
//        CreatedDate: Date;
//        CreatedBy?: string;
//        ModifiedDate?: Date;
//        ModifiedBy?: string;
//        IsActive: boolean;
//}
}
