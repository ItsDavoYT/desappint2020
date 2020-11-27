using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MotorPolicy.Models
{
    public class tblLink_VehiclesDrivers{
        
        public int lngDriveID {get;set;}
        
        public int lngVehicleID {get;set;}

        public tblDrivers Drivers{get;set;}
        public tblVehicles Vehicles{get;set;}
        
    }
    
}


