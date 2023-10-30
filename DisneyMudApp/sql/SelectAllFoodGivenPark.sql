SELECT
    p.ParkName,
    p.Description AS ParkDescription,
    a.AreaName,
    l.LocationName,
    f.FoodName,
    f.Price,
    f.Description AS FoodDescription,
    GROUP_CONCAT(DISTINCT al.AllergyName) AS Allergies,
    GROUP_CONCAT(DISTINCT t.TagName) AS Tags
FROM 
    Park p 
JOIN 
    Area a ON p.ParkName = a.ParkName
JOIN 
    Location l ON a.AreaName = l.AreaName
JOIN 
    Food f ON l.LocationName = f.LocationName
LEFT JOIN 
    Allergy al ON f.FoodName = al.FoodName
LEFT JOIN 
    Tag t ON f.FoodName = t.FoodName
WHERE 
    p.ParkName = "Disney's Animal Kingdom Theme Park"
GROUP BY
    p.ParkName, 
    a.AreaName, 
    l.LocationName, 
    f.FoodName, 
    f.Price, 
    f.Description
ORDER BY 
    a.AreaName, l.LocationName;
