using System.Collections;

namespace Libra2
{
    public class Building
    {
        private static uint lastBuildingId = 0;
        private uint buildingId { get; set; }
        private double? height { get; set; }
        private uint? floors { get; set; }
        private uint? apartments { get; set; }
        private uint? entrances { get; set; }


        internal Building(double? height, uint? floors, uint? apartments, uint? entrances)
        {
            buildingId = GenerateBuildingId();
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.entrances = entrances;
        }

        /// <summary>
        /// генерация номера здания
        /// </summary>
        private uint GenerateBuildingId()
        {
            lastBuildingId++;
            return lastBuildingId;
        }

        /// <summary>
        /// установка значений
        /// </summary>
        public void SetID(uint id) => buildingId = id;
        public void SetHeight(uint newHeight) => height = newHeight;
        public void SetFloors(uint newFloors) => floors = newFloors;
        public void SetApartments(uint newApartments) => height = newApartments;
        public void SetEntrances(uint newEntrances) => entrances = newEntrances;

        /// <summary>
        /// генерирование id
        /// </summary>
        public uint GetBuildingId()
        {
            return buildingId;
        }

        /// <summary>
        /// вывод высоты
        /// </summary>
        public double? GetHeight()
        {
            return height;
        }

        /// <summary>
        /// вывод кол-во этажей
        /// </summary>
        public uint? GetFloors()
        {
            return floors;
        }

        /// <summary>
        /// вывод кол-во квартир
        /// </summary>
        public uint? GetApartments()
        {
            return apartments;
        }

        /// <summary>
        /// вывод кол-во подъездов
        /// </summary>
        public uint? GetEntrances()
        {
            return entrances;
        }

        /// <summary>
        /// расчет высоты
        /// </summary>
        public double? GetFloorHeight()
        {
            return height / floors;
        }

        /// <summary>
        /// кол-во этажей в подъезде
        /// </summary>
        public uint? GetApartmentsPerEntrance()
        {
            return apartments / entrances;
        }
        public uint? GetApartmentsPerFloor()
        {
            return apartments / (floors * entrances);
        }

        /// <summary>
        /// вывод информации
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Здание ID: {buildingId}");
            Console.WriteLine($"Высота: {height} м");
            Console.WriteLine($"Этажность: {floors}");
            Console.WriteLine($"Количество квартир: {apartments}");
            Console.WriteLine($"Количество подъездов: {entrances}");
            Console.WriteLine($"Высота этажа: {GetFloorHeight():F2} м");
            Console.WriteLine($"Квартир на подъезд: {GetApartmentsPerEntrance()}");
            Console.WriteLine($"Квартир на этаже: {GetApartmentsPerFloor()}\n");
        }
    }
    public class BuildingCreator
    {
        private static Hashtable buildings = new Hashtable();
        private BuildingCreator() { }
        public static Building CreateBuild(double? height, uint? floors, uint? apartments, uint? entrances)
        {
            Building building = new Building(height, floors, apartments, entrances);
            buildings.Add(building.GetBuildingId(), building);
            return building;
        }
        public static Building CreateBuild(double? height, uint? floors)
        {
            Building building = new Building(height, floors, null, null);
            buildings.Add(building.GetBuildingId(), building);
            return building;
        }
        public static Building CreateBuild(double? height, uint? floors, uint? apartments)
        {
            Building building = new Building(height, floors, apartments, null);
            buildings.Add(building.GetBuildingId(), building);
            return building;
        }
        public static Building CreateBuild()
        {
            Building building = new Building(null, null, null, null);
            buildings.Add(building.GetBuildingId(), building);
            return building;
        }

        /// <summary>
        /// удаление здания по id
        /// </summary>
        public static void DeleteBuild(uint id)
        {
            if (buildings.ContainsKey(id))
            {
                buildings.Remove(id);
                Console.WriteLine($"здание {id} удалено ");
            }
            else Console.WriteLine($"здания {id} не существует");
        }

    }
}