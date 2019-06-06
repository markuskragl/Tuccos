//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AndritzHydro.Tuccos.Model;


//namespace AndritzHydro.Tuccos.Data 
//{
//    class FakeDatabaseLayer
//    {

//        public static ObservableCollection<Person> GetPeopleFromDatabase()
//        {
//            //Simulate database extaction
//            //For example from ADO DataSets or EF
//            return new ObservableCollection<Person>
//            {
//                new Person { FirstName="Tom", LastName="Jones", Age=80 },
//                new Person { FirstName="Dick", LastName="Tracey", Age=40 },
//                new Person { FirstName="Harry", LastName="Hill", Age=60 },
//            };
//        }



//        public string GetData(int value)
//        {
//            return value.ToString();
//        }

//        public Task<string> GetDataAsync(int value)
//        {
//            return System.Threading.Tasks.Task<string>.Run(() => this.ToString());
//        }

//    }
//}
