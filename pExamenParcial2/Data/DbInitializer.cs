using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HotelAGC.Models;

namespace HotelAGC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();

            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

        //Customers
            var customers = new Customer[]
            {
                new Customer { CustomerTitle = "SE", 
					CustomerForenames = "David", 
					CustomerSurnames = "Rodriguez de la Cruz",
                    CustomerDOB = DateTime.Parse("2020-09-12"), 
					CustomerAddressStreet = "Bisnagas 302", 
					CustomerAddressTown = "Zacatecas",
                    CustomerAddressCounty = "Mexico", 
					CustomerAddressPostalCode = "98507", 
					CustomerHomePhone = "123123",
                    CustomerWorkPhone = null, 
					CustomerMobilePhone = "123123", 
					CustomerEmail = "drc412@gmail.com" },
					
                new Customer { CustomerTitle = "Enfermera", 
					CustomerForenames = "Miriam", 
					CustomerSurnames = "Mendoza",
                    CustomerDOB = DateTime.Parse("2020-09-12"), 
					CustomerAddressStreet = "bisnagas", 
					CustomerAddressTown = "Monterrey",
                    CustomerAddressCounty = "Mexico", 
					CustomerAddressPostalCode = "95000", 
					CustomerHomePhone = "123123123",
                    CustomerWorkPhone = "123123123", 
					CustomerMobilePhone = "123123123", 
					CustomerEmail = "algo@hotmail.com" },
					
                new Customer { CustomerTitle = "Ing.", 
					CustomerForenames = "Angel", 
					CustomerSurnames = "Rodriguez de la Cruz",
                    CustomerDOB = DateTime.Parse("2020-09-12"), 
					CustomerAddressStreet = "Bisnagas 302", 
					CustomerAddressTown = "Zacatecas",
                    CustomerAddressCounty = "Mexico", 
					CustomerAddressPostalCode = "98507", 
					CustomerHomePhone = "123123",
                    CustomerWorkPhone = null, 
					CustomerMobilePhone = "123123", 
					CustomerEmail = "drc412@gmail.com" },
					
                new Customer { CustomerTitle = "Dr.", 
					CustomerForenames = "Maria", 
					CustomerSurnames = "Mendoza",
                    CustomerDOB = DateTime.Parse("2020-09-12"), 
					CustomerAddressStreet = "bisnagas", 
					CustomerAddressTown = "Monterrey",
                    CustomerAddressCounty = "Mexico", 
					CustomerAddressPostalCode = "95000", 
					CustomerHomePhone = "123123123",
                    CustomerWorkPhone = "123123123", 
					CustomerMobilePhone = "123123123", 
					CustomerEmail = "algo@hotmail.com" },
            };

            foreach (Customer ia in customers)
            {
                context.Customers.Add(ia);
            }
            context.SaveChanges();

        //Guest
            var guests = new Guest[]
            {
                new Guest { GuestTitle = "Licenciada", 
					GuestForenames = "Cecilia", 
					GuestSurnames = "Rodriguez de la Cruz", 
					GuestDOB = DateTime.Parse("2000-02-18"),
                    GuestAddressStreet = "3 organos 300", 
					GuestAddressTown = "Calera Zacatecas", 
					GuestAddressCounty = "Mexico", 
					GuestAddressPostalCode = "98507",
                    GuestContactPhone = "479 123 5432" },
                new Guest { GuestTitle = "Empresaria", 
					GuestForenames = "Josefina", 
					GuestSurnames = "De la Cruz Moncada", 
					GuestDOB = DateTime.Parse("1975-05-03"),
                    GuestAddressStreet = "Bisnagas 302", 
					GuestAddressTown = "Zacatecas", 
					GuestAddressCounty = "Mexico", 
					GuestAddressPostalCode = "98507",
                    GuestContactPhone = "4781156963" },
                new Guest { GuestTitle = "Sra.", 
					GuestForenames = "Cecilia", 
					GuestSurnames = "Rodriguez de la Cruz", 
					GuestDOB = DateTime.Parse("2000-02-18"),
                    GuestAddressStreet = "3 organos 300", 
					GuestAddressTown = "Calera Zacatecas", 
					GuestAddressCounty = "Mexico", 
					GuestAddressPostalCode = "98507",
                    GuestContactPhone = "479 123 5432" },
                new Guest { GuestTitle = "Empresaria", 
					GuestForenames = "Josefina", 
					GuestSurnames = "De la Cruz Moncada", 
					GuestDOB = DateTime.Parse("1975-05-03"),
                    GuestAddressStreet = "Bisnagas 302", 
					GuestAddressTown = "Zacatecas", 
					GuestAddressCounty = "Mexico", 
					GuestAddressPostalCode = "98507",
                    GuestContactPhone = "4781156963" }
            };

            foreach (Guest ib in guests)
            {
                context.Guests.Add(ib);
            }
            context.SaveChanges();
    
        //Booking
            var bookings = new Booking[]
            {
                new Booking { DateBookingMade = DateTime.Parse("2020-11-01"), 
					TimeBookingMade = DateTime.Parse("12:48:30"),
                    BookedStartDate = DateTime.Parse("2020-11-01"), 
					BookedEndDate =DateTime.Parse("2020-11-04"),
					TotalPaymentDueDate = DateTime.Parse("2020-10-01"), 
                    TotalPaymentDueAmount = 250, 
					TotalPaymentMadeOn = DateTime.Parse("2020-09-25"),
					BookingComments = null, 
                    CustomerID = customers.Single(c => c.CustomerForenames == "David").CustomerID
                    },
                new Booking {DateBookingMade = DateTime.Parse("2020-11-01"), 
					TimeBookingMade = DateTime.Parse("12:48:30"),
                    BookedStartDate = DateTime.Parse("2020-11-01"), 
					BookedEndDate =DateTime.Parse("2020-11-04"),
					TotalPaymentDueDate = DateTime.Parse("2020-10-01"), 
                    TotalPaymentDueAmount = 250, 
					TotalPaymentMadeOn = DateTime.Parse("2020-09-25"), 
					BookingComments = "Pago Realizado",
                    CustomerID = customers.Single(c => c.CustomerForenames == "Miriam").CustomerID 
                    },
                new Booking { DateBookingMade = DateTime.Parse("2020-11-01"), 
					TimeBookingMade = DateTime.Parse("12:48:30"),
                    BookedStartDate = DateTime.Parse("2020-11-01"), 
					BookedEndDate =DateTime.Parse("2020-11-04"),
					TotalPaymentDueDate = DateTime.Parse("2020-10-01"), 
                    TotalPaymentDueAmount = 250, 
					TotalPaymentMadeOn = DateTime.Parse("2020-09-25"), 
					BookingComments = "Pago Realizado",
                    CustomerID = customers.Single(c => c.CustomerForenames == "Angel").CustomerID 
                    },
                new Booking { DateBookingMade = DateTime.Parse("2020-11-01"), 
					TimeBookingMade = DateTime.Parse("12:48:30"),
                    BookedStartDate = DateTime.Parse("2020-11-01"), 
					BookedEndDate =DateTime.Parse("2020-11-04"),
					TotalPaymentDueDate = DateTime.Parse("2020-10-01"), 
                    TotalPaymentDueAmount = 250, 
					TotalPaymentMadeOn = DateTime.Parse("2020-09-25"), 
					BookingComments = "Pago Realizado",
                    CustomerID = customers.Single(c => c.CustomerForenames == "Miri").CustomerID 
                    }
            };

            foreach (Booking ic in bookings)
            {
                context.Bookings.Add(ic);
            }
            context.SaveChanges();

        //RoomType
            var roomtypes = new RoomType[]
            {
                new RoomType {roomType = roomType.Individual},
                new RoomType {roomType = roomType.Doble},
                new RoomType {roomType = roomType.Tripe},
                new RoomType {roomType = roomType.Suite},
                new RoomType {roomType = roomType.RoyalSuite},
                new RoomType {roomType = roomType.TopLevelSuite}
            };

            foreach (RoomType id in roomtypes)
            {
                context.RoomTypes.Add(id);
            }
            context.SaveChanges();

        //RoomBand
            var roombands = new RoomBand[]
            {
                new RoomBand {BandDesc = "A"},
                new RoomBand {BandDesc = "AB"},
                new RoomBand {BandDesc = "AC"},
                new RoomBand {BandDesc = "AD"},
                new RoomBand {BandDesc = "AF"}
            };

            foreach (RoomBand ie in roombands)
            {
                context.RoomBands.Add(ie);
            }
            context.SaveChanges();

        //RoomPrice
            var roomprices = new RoomPrice[]
            {
                new RoomPrice {roomPrice = 1000},
                new RoomPrice {roomPrice = 2000},
                new RoomPrice {roomPrice = 3000},
                new RoomPrice {roomPrice = 4000},
                new RoomPrice {roomPrice = 5000}
            };

            foreach (RoomPrice ig in roomprices)
            {
                context.RoomPrices.Add(ig);
            }
            context.SaveChanges();

        //Room
            var rooms = new Room[]
            {
                new Room {Floor = "4", 
					AdditionalNotes = "Habitacion Individual $1000 por dia",
                    RoomTypeID = roomtypes.Single( c => c.roomType == roomType.Individual).RoomTypeID,
                    RoomBandID = roombands.Single( i => i.BandDesc == "A").RoomBandID,
                    RoomPriceID = roomprices.Single( s => s.roomPrice == 1000).RoomPriceID
                },
                new Room {Floor = "3", 
					AdditionalNotes = "Habitacion Doble $2000 por dia",
                    RoomTypeID = roomtypes.Single( c => c.roomType == roomType.Doble).RoomTypeID,
                    RoomBandID = roombands.Single( i => i.BandDesc == "AB").RoomBandID,
                    RoomPriceID = roomprices.Single( s => s.roomPrice == 2000).RoomPriceID
                },
                new Room {Floor = "4", 
					AdditionalNotes = "Habitacion Triple $3000 por dia",
                    RoomTypeID = roomtypes.Single( c => c.roomType == roomType.Cuadruple).RoomTypeID,
                    RoomBandID = roombands.Single( i => i.BandDesc == "AD").RoomBandID,
                    RoomPriceID = roomprices.Single( s => s.roomPrice == 300).RoomPriceID
                },
                new Room {Floor = "6", 
					AdditionalNotes = "Habitacion Royal Suit $4000 por dia",
                    RoomTypeID = roomtypes.Single( c => c.roomType == roomType.Suite).RoomTypeID,
                    RoomBandID = roombands.Single( i => i.BandDesc == "AF").RoomBandID,
                    RoomPriceID = roomprices.Single( s => s.roomPrice == 4000).RoomPriceID
                } 
            };

            foreach (Room ih in rooms)
            {
                context.Rooms.Add(ih);
            }
            context.SaveChanges();
        
        //BookingRoom
            var bookingsrooms = new BookingRoom[]
            {
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2020-01-02")).BookingID,
                    RoomID = rooms.Single(i => i.Floor == "2").RoomID,
                    GuestID = guests.Single(s => s.GuestForenames == "David").GuestID
                },
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2020-01-02")).BookingID,
                    RoomID = rooms.Single(i => i.Floor == "1").RoomID,
                    GuestID = guests.Single(s => s.GuestForenames == "Miriam").GuestID
                },
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2020-01-02")).BookingID,
                    RoomID = rooms.Single(i => i.Floor == "4").RoomID,
                    GuestID = guests.Single(s => s.GuestForenames == "Angel").GuestID
                },
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2020-01-02")).BookingID,
                    RoomID = rooms.Single(i => i.Floor == "5").RoomID,
                    GuestID = guests.Single(s => s.GuestForenames == "Miri").GuestID
                }
            };

            foreach (BookingRoom i in bookingsrooms)
            {
                context.BookingsRooms.Add(i);
            }
            context.SaveChanges();

            foreach (BookingRoom ix in bookingsrooms)
            {
                var bookingroomInDataBase = context.BookingsRooms.Where(
                    z =>
                            z.Booking.BookingID == ix.BookingID &&
                            z.Room.RoomID == ix.RoomID &&
                            z.Guest.GuestID == ix.GuestID).SingleOrDefault();
                if (bookingroomInDataBase == null)
                {
                    context.BookingsRooms.Add(ix);
                }
            }
            context.SaveChanges();

        //PaymentMethod
            var paymentmethods = new PaymentMethod[]
            {
                new PaymentMethod {paymentMethod = "Paypal"},
                new PaymentMethod {paymentMethod = "Tarjeta de Credito"},
                new PaymentMethod {paymentMethod = "Tarjeta de Debito"},
                new PaymentMethod {paymentMethod = "Transferencia Bancaria"},
                new PaymentMethod {paymentMethod = "Efectivo"}
            };

            foreach (PaymentMethod ip in paymentmethods)
            {
                context.PaymentMethods.Add(ip);
            }
            context.SaveChanges();

        //Payment
            var payments = new Payment[]
            {
                new Payment {PaymentAmount = 6500, 
					PaymentComments = "Pago total",
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2021-01-05")).BookingID,
                    CustomerID = customers.Single(i => i.CustomerForenames == "David").CustomerID,
                    PaymentMethodID = paymentmethods.Single(s => s.paymentMethod == "Efectivo").PaymentMethodID
                    },
                new Payment {PaymentAmount = 5000, 
					PaymentComments = "Pago saldado totalmente",
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2021-01-05")).BookingID,
                    CustomerID = customers.Single(i => i.CustomerForenames == "Miriam").CustomerID,
                    PaymentMethodID = paymentmethods.Single(s => s.paymentMethod == "Transferencia Bancaria").PaymentMethodID
                    },
                new Payment {PaymentAmount = 10000, 
					PaymentComments = "Pago saldado parcialmente",
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2021-01-05")).BookingID,
                    CustomerID = customers.Single(i => i.CustomerForenames == "Angel").CustomerID,
                    PaymentMethodID = paymentmethods.Single(s => s.paymentMethod == "Tarjeta de debito").PaymentMethodID
                    },
                new Payment {PaymentAmount = 6000, 
					PaymentComments = "Pago saldado totalmente",
                    BookingID = bookings.Single(c => c.DateBookingMade == DateTime.Parse("2021-01-05")).BookingID,
                    CustomerID = customers.Single(i => i.CustomerForenames == "Miri").CustomerID,
                    PaymentMethodID = paymentmethods.Single(s => s.paymentMethod == "Paypal").PaymentMethodID
                    }
            };

            foreach (Payment iq in payments)
            {
                context.Payments.Add(iq);
            }
            context.SaveChanges();
            
        //FacilitieList
            var facilitielists = new FacilitieList[]
            {
                new FacilitieList {FacilityDesc = "(1)Cama individual - (1)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Otros muebles"},
                new FacilitieList {FacilityDesc = "(2)Cama individual - (1)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles"},
                new FacilitieList {FacilityDesc = "(4)Cama individual - (2)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles"},
                new FacilitieList {FacilityDesc = "(2)Cama matrimonial - (2)TV - Telefono - (1)Computadora - Refrigerador - Microondas - Internet - Cafetera - Plancha - Jacuzzi - Otros muebles"},
                new FacilitieList {FacilityDesc = "(2)Cama matrimonial - (1)TV - Telefono - (1)Computadora- Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles"},
                new FacilitieList {FacilityDesc = "(2)Cama king-size - (2)TV - Telefono - (2)Computadora - Refrigerador - Microondas - Internet - Cafetera - Plancha,  Jacuzzi - Alberca - Otros muebles"}
            };

            foreach (FacilitieList io in facilitielists)
            {
                context.FacilitieLists.Add(io);
            }
            context.SaveChanges();

        //RoomFacilities
            var roomsfacilities = new RoomFacilities[]
            {
                new RoomFacilities {FacilityDetails = "Servicios basicos",
                RoomID = rooms.Single(c => c.Floor == "2").RoomID,
                FacilityID = facilitielists.Single(s => s.FacilityDesc == "(1)Cama individual - (1)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Otros muebles").FacilityID,
                },
                new RoomFacilities {FacilityDetails = "Servicios basicos",
                RoomID = rooms.Single(c => c.Floor == "3").RoomID,
                FacilityID = facilitielists.Single(s => s.FacilityDesc == "(2)Cama individual - (1)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles").FacilityID,
                },
                new RoomFacilities {FacilityDetails = "Servicios basicos + extra",
                RoomID = rooms.Single(c => c.Floor == "4").RoomID,
                FacilityID = facilitielists.Single(s => s.FacilityDesc == "(4)Cama individual - (2)TV - Telefono - Refrigerador - Microondas - Internet - Cafetera - Plancha - Otros muebles").FacilityID,
                },
                new RoomFacilities {FacilityDetails = "Servicios basicos + extra",
                RoomID = rooms.Single(c => c.Floor == "6").RoomID,
                FacilityID = facilitielists.Single(s => s.FacilityDesc == "(2)Cama matrimonial - (2)TV - Telefono - (1)Computadora - Refrigerador - Microondas - Internet - Cafetera - Plancha - Jacuzzi - Otros muebles").FacilityID
                }
            };

            foreach (RoomFacilities im in roomsfacilities)
            {
                context.RoomsFacilities.Add(im);
            }
            context.SaveChanges();

            foreach (RoomFacilities ir in roomsfacilities)
            {
                var roomfacilitiesInDataBase = context.RoomsFacilities.Where(
                    w =>
                            w.Room.RoomID == ir.RoomID &&
                            w.FacilitieList.FacilityID == ir.FacilityID).SingleOrDefault();
                if (roomfacilitiesInDataBase == null)
                {
                    context.RoomsFacilities.Add(ir);
                }
            }
            context.SaveChanges();
        }
    }
}