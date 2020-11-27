using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotorPolicy.Models;


namespace MotorPolicy.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PoliceContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Drivers.Any())
            {
                return;   // DB has been seeded
            }

            var driver = new tblDrivers[]
            {
                new tblDrivers { strTitle = "Chofer",
                                 strFirstName ="David",
                                 strLastName="Rodriguez de la Cruz",
                                 dteDOB =DateTime.Parse("2012-09-01"),
                                 dteDateLicensed = DateTime.Parse("2012-09-01"), 
                                 strLicenseReference ="123213", 
                                 strAddress_Street="Bisnaga",
                                 strAddress_TownVillage="Calera Zacatecas",
                                 strAddress_Country="Mexico",
                                 strAddress_PostCode="98507",
                                 strContactDayPhone="123456789",
                                 strContactNightPhone ="123456789"},
                 new tblDrivers {strTitle = "Camionero",
                                 strFirstName ="Angel",
                                 strLastName="Rodriguez de la Cruz",
                                 dteDOB =DateTime.Parse("2012-09-01"),
                                 dteDateLicensed = DateTime.Parse("2012-09-01"), 
                                 strLicenseReference ="123124", 
                                 strAddress_Street="Bisnagas",
                                 strAddress_TownVillage="Calera Zacatecas",
                                 strAddress_Country="Mexico",
                                 strAddress_PostCode="98507",
                                 strContactDayPhone="123456789",
                                 strContactNightPhone ="123456789"},
                 new tblDrivers {strTitle = "Particular",
                                 strFirstName ="Cecilia",
                                 strLastName="Rodriguez de la Cruz",
                                 dteDOB =DateTime.Parse("2012-09-01"),
                                 dteDateLicensed = DateTime.Parse("2012-09-01"), 
                                 strLicenseReference ="123125", 
                                 strAddress_Street="Bisnagas",
                                 strAddress_TownVillage="Calera Zacatecas",
                                 strAddress_Country="Mexico",
                                 strAddress_PostCode="98507",
                                 strContactDayPhone="123456789",
                                 strContactNightPhone ="123456789"},
                 new tblDrivers {strTitle = "Particular",
                                 strFirstName ="Carlos",
                                 strLastName="Chano",
                                 dteDOB =DateTime.Parse("2012-09-01"),
                                 dteDateLicensed = DateTime.Parse("2012-09-01"), 
                                 strLicenseReference ="123126", 
                                 strAddress_Street="Abasolo",
                                 strAddress_TownVillage="Fresnillo Zacatecas",
                                 strAddress_Country="Mexico",
                                 strAddress_PostCode="98507",
                                 strContactDayPhone="123456789",
                                 strContactNightPhone ="123456789"}                                                
            };

            foreach (tblDrivers s in driver)
            {
                context.Drivers.Add(s);
            }
            context.SaveChanges();

            var vehicles = new tblVehicles[]
            {
                new tblVehicles{strVehicleChassisNo="123123",
                                strVehicleEngineNo="123123",
                                strVehicleEngineSize="large",
                                strVehicleMake="GM",
                                strVehicleModel="Chevi",
                                lngRegistrationYear=0,
                                strVehicleRegistrationNo="123123",
                                curVehicleValue=0,
                                lngInsuranceGroup=0,
                                strPolicyReferenceNo="123123"},
                new tblVehicles{strVehicleChassisNo="123123",
                                strVehicleEngineNo="123123",
                                strVehicleEngineSize="Medium",
                                strVehicleMake="GM",
                                strVehicleModel="Beat",
                                lngRegistrationYear=0,
                                strVehicleRegistrationNo="123123",
                                curVehicleValue=0,
                                lngInsuranceGroup=0,
                                strPolicyReferenceNo="123123"},
                new tblVehicles{strVehicleChassisNo="123123",
                                strVehicleEngineNo="123123",
                                strVehicleEngineSize="small",
                                strVehicleMake="GM",
                                strVehicleModel="Sentra",
                                lngRegistrationYear=0,
                                strVehicleRegistrationNo="123123",
                                curVehicleValue=0,
                                lngInsuranceGroup=0,
                                strPolicyReferenceNo="123123"},
                new tblVehicles{strVehicleChassisNo="123123",
                                strVehicleEngineNo="123123",
                                strVehicleEngineSize="Medium",
                                strVehicleMake="GM",
                                strVehicleModel="Tsuru",
                                lngRegistrationYear=0,
                                strVehicleRegistrationNo="123123",
                                curVehicleValue=0,
                                lngInsuranceGroup=0,
                                strPolicyReferenceNo="123123"}
            };

            foreach (tblVehicles i in vehicles)
            {
                context.Vehicles.Add(i);
            }
            context.SaveChanges();

            var codes = new tblViolationCodes[]//
            {
                new tblViolationCodes{strViolationCode="123123",
                                      strViolationDescription="Se cruzo un rojo jovenazo",
                                      strAdditionalInfo="INFO ADDD"},
                new tblViolationCodes{
                                      strViolationCode="123124",
                                      strViolationDescription="Se cruzo un rojo jovenazo",
                                      strAdditionalInfo="INFO ADDD"},
                new tblViolationCodes{
                                      strViolationCode="123125",
                                      strViolationDescription="Se cruzo un rojo jovenazo",
                                      strAdditionalInfo="INFO ADDD"},
                new tblViolationCodes{
                                      strViolationCode="123126",
                                      strViolationDescription="Se cruzo un rojo jovenazo",
                                      strAdditionalInfo="INFO ADDD"}
                
            };

            foreach (tblViolationCodes d in codes)
            {
                context.ViolationCodes.Add(d);
            }
            context.SaveChanges();

            var polices = new tblPolicies[]//
            {
                new tblPolicies{strPolicyReferenceNo="123123",
                                dtePolicyEffectiveDate= DateTime.Parse("2012-09-01"),
                                dtePolicyExpirationDate= DateTime.Parse("2012-09-01"),
                                curTotalPolicyCost=12,
                                lngPayerId=1,
                                dteLastUpdate = DateTime.Parse("2012-09-01"),
                                memAdditionalInfo="bla bla bla bla" 
                },
                new tblPolicies{strPolicyReferenceNo="123124",
                                dtePolicyEffectiveDate= DateTime.Parse("2012-09-01"),
                                dtePolicyExpirationDate= DateTime.Parse("2012-09-01"),
                                curTotalPolicyCost=123,
                                lngPayerId=2,
                                dteLastUpdate = DateTime.Parse("2012-09-01"),
                                memAdditionalInfo="hola soy una informacion adicional"
                },
                new tblPolicies{strPolicyReferenceNo="123125",
                                dtePolicyEffectiveDate= DateTime.Parse("2012-09-01"),
                                dtePolicyExpirationDate= DateTime.Parse("2012-09-01"),
                                curTotalPolicyCost=12345,
                                lngPayerId=3,
                                dteLastUpdate = DateTime.Parse("2012-09-01"),
                                memAdditionalInfo="pipo pipo pipo pipi"
                },
                new tblPolicies{strPolicyReferenceNo="123126",
                                dtePolicyEffectiveDate= DateTime.Parse("2012-09-01"),
                                dtePolicyExpirationDate= DateTime.Parse("2012-09-01"),
                                curTotalPolicyCost=50000,
                                lngPayerId=4,
                                dteLastUpdate = DateTime.Parse("2012-09-01"),
                                memAdditionalInfo="profe si esto lo llega a ver pongame un 9 :P"
                }
            };

            foreach (tblPolicies c in polices)
            {
                context.Policies.Add(c);
            }
            context.SaveChanges();

            var insurance = new tblInsuranceGroups[]
            {
               new tblInsuranceGroups{lngInsuranceGroup=1,
                                      memInsuranceGroupDetails="detalles detalles simples detalles"},
               new tblInsuranceGroups{lngInsuranceGroup=2,
                                      memInsuranceGroupDetails="hola soy mas detalles"},
               new tblInsuranceGroups{lngInsuranceGroup=3,
                                      memInsuranceGroupDetails="simples detalles"},
               new tblInsuranceGroups{lngInsuranceGroup=4,
                                      memInsuranceGroupDetails="he ya no se que poner :'v"},
            };

            foreach (tblInsuranceGroups o in insurance)
            {
                context.InsuranceGroups.Add(o);
            }
            context.SaveChanges();

            var linkViolationDrivers = new tblLink_ViolationsDrivers[]//
            {
                new tblLink_ViolationsDrivers{lngDriveID=1,
                                              strViolationCode="123123"
                                              },
                new tblLink_ViolationsDrivers{lngDriveID=2,
                                              strViolationCode="123124"
                                              },
                new tblLink_ViolationsDrivers{lngDriveID=3,
                                              strViolationCode="123125"
                                              },
                new tblLink_ViolationsDrivers{lngDriveID=4,
                                              strViolationCode="123126"
                                              },
            };

             foreach (tblLink_ViolationsDrivers e in linkViolationDrivers)
            {
                context.link_ViolationsDrivers.Add(e);
            }
            context.SaveChanges();


            context.SaveChanges();

            var linkVehiclesDrivers = new tblLink_VehiclesDrivers[]
            {
                new tblLink_VehiclesDrivers{lngDriveID=1,
                                            lngVehicleID=1},
                new tblLink_VehiclesDrivers{lngDriveID=2,
                                            lngVehicleID=2},
                new tblLink_VehiclesDrivers{lngDriveID=3,
                                            lngVehicleID=3},
                new tblLink_VehiclesDrivers{lngDriveID=4,
                                            lngVehicleID=4},
            };

            foreach (tblLink_VehiclesDrivers e in linkVehiclesDrivers)
            {
                context.link_VehiclesDrivers.Add(e);
            }
            context.SaveChanges();

        }
    }
}
