using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LORD.JSON
{
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var jObject = JObject.Load(reader);
                var target = Create(objectType, jObject);
                serializer.Populate(jObject.CreateReader(), target);
                return target;
            }
            catch (JsonReaderException)
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public class WeaponConverter : JsonCreationConverter<Weapon>
    {
        protected override Weapon Create(Type objectType, JObject jObject)
        {
            switch((Weapons.WeaponIDs)jObject["Type"].Value<int>())
            {
                case Weapons.WeaponIDs.STICK:
                    return Weapon.CreateWeapon(Weapons.WeaponIDs.STICK);
                    
            }
            return null;
        }

        
    }

    public class PlayerConverter : JsonCreationConverter<Player>
    {
        protected override Player Create(Type objectType, JObject jObject)
        {
            switch(jObject["WeaponType"].Value<int>())
            {
                case 1:
                    Console.WriteLine("Player has a stick");
                    break;
                case 2:Console.WriteLine("Player had a dagger");
                    break;
            }

            switch(jObject["ArmourType"].Value<int>())
            {
                case 1:
                    Console.WriteLine("Player has a coat");
                    break;
                case 2:
                    Console.WriteLine("Player has a heavy coat");
                    break;
            }

            return new Player("temp", "temp");
        }
    }
}
