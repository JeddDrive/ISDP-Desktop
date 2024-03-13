using JeddoreISDPDesktop.DAO_Classes;
using JeddoreISDPDesktop.Entity_Classes;
using System.Collections.Generic;

namespace JeddoreISDPDesktop.Helper_Classes
{
    //public static helper class
    public static class DeliveryCalculator
    {
        //public function that gets the distance (in KM) from a warehouse to a site based on the siteID sent in
        public static int GetWarehouseToStoreDistance(int siteID)
        {
            //distanceKM var to be returned - in KM
            int distanceKM = 0;

            //if - bullseye headquarters
            if (siteID == 3)
            {
                distanceKM = 2;
            }

            //else if -  saint john retail
            if (siteID == 4)
            {
                distanceKM = 5;
            }

            //else if - sussex retail
            else if (siteID == 5)
            {
                distanceKM = 73;
            }

            //else if - moncton retail
            else if (siteID == 6)
            {
                distanceKM = 151;
            }

            //else if - dieppe retail
            else if (siteID == 7)
            {
                distanceKM = 158;
            }

            //else if - oromocto retail
            else if (siteID == 8)
            {
                distanceKM = 99;
            }

            //else if - fredericton retail
            else if (siteID == 9)
            {
                distanceKM = 116;
            }

            //else if - miramichi retail
            else if (siteID == 10)
            {
                distanceKM = 273;
            }

            //return the distanceKM
            return distanceKM;
        }

        //public function that can calculate a delivery's cost once delivered
        public static decimal CalculateDeliveryCost(Vehicle vehicle, int distanceKM, decimal deliveryTime)
        {
            //calculating the truck cost first
            decimal deliveryTruckCost = deliveryTime * vehicle.hourlyTruckCost;

            //now calculating the cost per KM
            decimal deliveryCostPerKM = distanceKM * vehicle.costPerKm;

            //now can calculate the total cost of the delivery
            decimal deliveryTotalCost = deliveryTruckCost + deliveryCostPerKM;

            //return the decimal total cost
            return deliveryTotalCost;
        }

        //public function - get the recommeneded vehicle type/size for a delivery
        public static string GetRecommendedVehicleType(decimal weight)
        {
            //string to be returned
            string vehicleType = "";

            //getting list of all vehicles
            List<Vehicle> vehiclesList = VehicleAccessor.GetAllVehiclesList();

            //want a vehicle obj to store the previous vehicle in the below foreach loop
            Vehicle previousVehicle = null;

            //if weight is zero, then return none needed
            if (weight == 0.0m)
            {
                vehicleType = "None Needed";
            }

            else if (weight > 0.0m && weight <= 1000.0m)
            {
                vehicleType = "Van";
            }

            else if (weight > 1000.0m && weight <= 5000.0m)
            {
                vehicleType = "Small";
            }

            else if (weight > 5000.0m && weight <= 10000.0m)
            {
                vehicleType = "Medium";
            }

            //else - heavy vehicle
            else
            {
                vehicleType = "Heavy";
            }

            //foreach loop 
            /* foreach (Vehicle vehicle in vehiclesList)
            {
                if (vehicle.maxWeight <= weight && vehicle == null)
                {
                    vehicleType = vehicle.vehicleType;
                }

                if (previousVehicle != null && vehicle.maxWeight <= weight && vehicle.maxWeight < previousVehicle.maxWeight)
                {
                    vehicleType = vehicle.vehicleType;
                }

                previousVehicle = vehicle;
            } */

            //return the string
            return vehicleType;
        }
    }
}
