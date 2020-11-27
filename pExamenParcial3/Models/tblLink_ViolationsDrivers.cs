using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MotorPolicy.Models
{
    public class tblLink_ViolationsDrivers{
        public int lngDriveID {get;set;}
        
        public string strViolationCode {get;set;}


        public tblDrivers Drivers{get;set;}
        public tblViolationCodes ViolationCodes{get;set;}  

    }

}