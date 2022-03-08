using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;

var fileContent = await File.ReadAllTextAsync("data.json");
var cars = JsonSerializer.Deserialize<CarData[]>(fileContent);

//Display the number of models per make that appears after 2008
// cars.Where(x=> x.Year >= 2008)
// .GroupBy(car => car.Make)
//         .Select(c => new{c.Key, NumOfModel = c.Count()}).ToList()
//         .ForEach(car => Console.WriteLine($"{car.Key}: {car.NumOfModel}"));

//Display the number of models per make that appears after 2008
//Make should be display with number zero if no model after 2008
// cars.GroupBy(car => car.Make)
//     .Select(c => new{c.Key, NumOfModel = c.Where(x=> x.Year >= 2008).Count()}).ToList()
//     .ForEach(car => Console.WriteLine($"{car.Key}: {car.NumOfModel}"));

//Display the of makes that have atleast 2 models with more than 400hp
// cars.Where(c => c.HP >= 400).GroupBy(car => car.Make)
//     .Select(c => new{c.Key, NumOfModel = c.Count()})
//     .Where(x => x.NumOfModel >= 2).ToList()
//     .ForEach(car => Console.WriteLine($"{car.Key}: {car.NumOfModel}"));

//Display avrage hp per make 
// cars.GroupBy(car => car.Make)
//     .Select(c => new {make= c.Key, AvarageHp = c.Average(ahp => ahp.HP) })
//     .ToList()
//     .ForEach(make => Console.WriteLine($"{make.make}: {make.AvarageHp}"));


// How many make build cars with HP between 0...100, 101...200, 201...300, 301....400
cars.GroupBy(car => car.HP switch
{
   <= 100 => "0...100",
   <= 200 => "101...200",
   <= 300 => "201...300",
   <= 400 => "301...400", 
   _ => "401...500"
}).Select(car => new {category = car.Key, NumOfMake = car.Select(c=> c.Make).Distinct().Count()})
    .ToList()
    .ForEach(c=> Console.WriteLine($"{c.category}: {c.NumOfMake}"));



class CarData{
    [JsonPropertyName("id")]
    public int ID { get; set; }
    [JsonPropertyName("car_make")]
    public string Make { get; set; }
    [JsonPropertyName("car_models")]
    public string Model { get; set; }
    [JsonPropertyName("car_year")]
    public int Year { get; set; }
    [JsonPropertyName("number_of_doors")]
    public int Num_of_doors { get; set; }
    [JsonPropertyName("hp")]
    public int HP { get; set; }

    public string toString(){
        return $"The {this.Make} car {this.Model} Registration year {this.Year} has {this.Num_of_doors} doors";
    }

}