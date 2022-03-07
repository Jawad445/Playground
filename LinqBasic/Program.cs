using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

var fileContent = await File.ReadAllTextAsync("data.json");
var cars = JsonSerializer.Deserialize<CarData[]>(fileContent);

// Print all cars with atleast 4 doors
 var car_with_four_doors = cars.Where(car=> car.Num_of_doors >= 4).ToList();

foreach(var item in car_with_four_doors)
{
    Console.WriteLine(item.toString());
}


// Print all Mazda cars with atleast 4 doors
var mazdacars = cars.Where(car=> car.Num_of_doors >= 4 && car.Make.Equals("mazda", StringComparison.OrdinalIgnoreCase)).ToList();

foreach(var item in mazdacars)
{
    Console.WriteLine(item.toString());
}

//Print Make and Model for all make starts with 'M'
cars.Where(car => car.Make.StartsWith("M"))
                    .Select(car => $"{car.Make} {car.Model}").ToList()
                    .ForEach(car => Console.WriteLine(car));


// Display 10 Most powerfull cars
cars.OrderByDescending(car => car.HP).Take(10).ToList()
    .ForEach(car => Console.WriteLine(car.toString()));



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
