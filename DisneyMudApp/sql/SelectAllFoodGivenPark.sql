SELECT Park.ParkName, Area.AreaName, Location.LocationName, Food.FoodName
FROM Park
JOIN Area ON Park.ParkName = Area.ParkName
JOIN Location ON Area.AreaName = Location.AreaName
JOIN Food ON Location.LocationName = Food.LocationName
WHERE Area.ParkName = "Disney's Animal Kingdom Theme Park";