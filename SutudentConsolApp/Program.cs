using Business.Concrete;
using Business.Validations;
using DataAccess.Context;
using DataAccess.EFCore;
using Entities.TableModels;
using System.Text;

namespace SutudentConsolApp
{
    internal class Program
    {
        readonly static StudentValidation rules;
        readonly static MyDbContext myDb;
        readonly static StudentDal studentDal;
        readonly static StudentManager manager;
        static Program()
        {
            rules = new();
            myDb = new();
            studentDal = new StudentDal(myDb);
            manager = new StudentManager(rules, studentDal);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Starting Proqram!");
            Console.WriteLine("Welcome!");
            bool isCoun = true;
            while (isCoun)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1.Tələbə əlavə et.");
                Console.WriteLine("2.Tələbənin məlumatlarını yenilə.");
                Console.WriteLine("3.Tələbə sil.");
                Console.WriteLine("4.Bütün tələbələri göstər.");
                Console.WriteLine("5.Tələbəni ID-yə görə göstər.");
                Console.WriteLine("0.Proqramı bağla.");
                Console.WriteLine("-----------------------------------");

                if(int.TryParse(Console.ReadLine(),out int value))
                {
                    switch (value)
                    {
                        case 0:
                            Console.Clear();
                            isCoun = false;
                            Console.WriteLine("Proqram Bağlandı!");
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("----------Yeni Tələbə----------");
                            Student newStud = new();
                            Console.Write("Adı: ");
                            newStud.FirstName = Console.ReadLine();
                            Console.Write("Soyad: ");
                            newStud.LastName = Console.ReadLine();
                            var result = manager.Add(newStud);
                            Console.WriteLine(result.Message);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("----------Yenilənən Tələbə----------");
                            int id = int.Parse(Console.ReadLine());
                            Student updStud = manager.GetById(id).Data;
                            Console.Write("Adı: ");
                            updStud.FirstName = Console.ReadLine();
                            Console.Write("Soyad: ");
                            updStud.LastName = Console.ReadLine();
                            var upResult = manager.Update(updStud);
                            Console.WriteLine(upResult.Message);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("----------Silinəcək Tələbə----------");
                            int idD = int.Parse(Console.ReadLine());
                            Console.WriteLine(manager.Delete(idD).Message);
                            break;
                        case 4:
                            Console.Clear();
                            var getAllResult = manager.GetAll();
                            if(getAllResult.Success)
                            {
                                foreach (var item in getAllResult.Data)
                                {
                                    Console.WriteLine($"ID: {item.ID}");
                                    Console.WriteLine($"Ad: {item.FirstName}");
                                    Console.WriteLine($"Soyad: {item.LastName}");
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                }
                            }
                            else
                                Console.WriteLine(getAllResult.Message);
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("----------Axtarılan Tələbə----------");
                            int byId = int.Parse(Console.ReadLine());
                            var getByIdResult =  manager.GetById(byId);
                            if(getByIdResult.Success)
                            {
                                var data = getByIdResult.Data;
                                Console.WriteLine($"ID: {data.ID}");
                                Console.WriteLine($"Ad: {data.FirstName}");
                                Console.WriteLine($"Soyad: {data.LastName}");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            }
                            else
                                Console.WriteLine(getByIdResult.Message);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Seçim doğru deyiı!");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Səhv simvol!!");
                }
            }
        }
    }
}
