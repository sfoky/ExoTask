using System;
using DAL.Services;
using DAL.Entities;
using System.Collections.Generic;


namespace Consommation
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryService categoryServ = new CategoryService();
            PersonService personServ = new PersonService();
            TaskService taskServ = new TaskService();

            //#region GetAllCat
            //IEnumerable<Category> allCategory = categoryServ.GetAll();
            //foreach (Category category in allCategory)
            //{
            //    Console.WriteLine($"Id :  {category.Id} - Nom :  {category.Name}");
            //} 
            //#endregion


            //#region GetCatById
            //Category categoryToGet = categoryServ.GetById(1);
            //Console.WriteLine($"{categoryToGet.Id} - {categoryToGet.Name}");
            //#endregion

            //#region AddCat
            //Category coder = new Category()
            //{
            //    Id = 0,
            //    Name = "Coder"
            //};
            //int nbrCategoryAdd = categoryServ.AddCategory(coder);
            //Console.WriteLine($"Nombre de categorie ajouter  : {nbrCategoryAdd}");
            //#endregion

            //#region DeleteCat
            //int nbrCategoryDel = categoryServ.DeleteCategory(7);
            //Console.WriteLine($"Nombre de categorie supprimer  : {nbrCategoryDel}");
            //#endregion

            //#region GetAllPerson
            //IEnumerable<Person> allPerson = personServ.GetAll();
            //foreach (Person person in allPerson)
            //{
            //    Console.WriteLine($"Id :  {person.Id} - Nom :  {person.FirstName} - Prenom :{person.LastName} ");
            //}
            //#endregion


            //#region GetPersonById
            //Person personToGet = personServ.GetById(1);
            //Console.WriteLine($"Id :  {personToGet.Id} - Nom :  {personToGet.FirstName} - Prenom :{personToGet.LastName} ");
            //#endregion

            #region AddPerson
            Person sylvain = new Person()
            {
                Id = 0,
                LastName = "Sylvain",
                FirstName = "Fok",
            };
            int nbrPersonAdd = personServ.AddPerson(sylvain);
            Console.WriteLine($"Nombre de categorie ajouter  : {nbrPersonAdd}");
            #endregion

            //#region DeletePerson
            //sylvain = personServ.GetById(6);
            //int nbrPersonDel = personServ.DeletePerson(sylvain);
            //Console.WriteLine($"Nombre de categorie supprimer  : {nbrPersonDel}"); 
            //#endregion

            //#region UpdatePerson
            //sylvain = personServ.GetById(7);
            //sylvain.FirstName = "Fok";
            //sylvain.LastName = "Jean";
            //personServ.UpdatePerson(sylvain); 
            //#endregion

            //#region GetTaskAll

            //IEnumerable<Task> allTask = taskServ.GetAll();
            //foreach (Task task in allTask)
            //{
            //    Console.WriteLine($"Id :  {task.Id} - Nom :  {task.Name} - IdCat : {task.IdCategory} - IdPersonne : {task.IdPerson} \n- Description : {task.Descr} \n - Date de Creation : {task.CreationDate} - Date de fin prévue : {task.EndingDateMax} - Date de fin réel : {task.EndingDate}");
            //} 
            //#endregion

            //#region GetTaskById
            //Task taskToGet = taskServ.GetById(1);
            //Console.WriteLine($"Id :  {taskToGet.Id} - Nom :  {taskToGet.Name} - IdCat : {taskToGet.IdCategory} - IdPersonne : {taskToGet.IdPerson} \n- Description : {taskToGet.Descr} \n - Date de Creation : {taskToGet.CreationDate} - Date de fin prévue : {taskToGet.EndingDateMax} - Date de fin réel : {taskToGet.EndingDate}"); 
            //#endregion

            //#region GetTaskByCat
            //Category gardening = categoryServ.GetById(1);
            //IEnumerable<Task> gardeningTask = taskServ.GetByCat(gardening);
            //foreach (Task task in gardeningTask)
            //{
            //    Console.WriteLine($"Id :  {task.Id} - Nom :  {task.Name} - IdCat : {task.IdCategory} - IdPersonne : {task.IdPerson} \n- Description : {task.Descr} \n - Date de Creation : {task.CreationDate} - Date de fin prévue : {task.EndingDateMax} - Date de fin réel : {task.EndingDate}");
            //} 
            //#endregion

            //#region GetTaskByPerson
            //Person Georges = personServ.GetById(1);
            //IEnumerable<Task> georgeTask = taskServ.GetByPerson(Georges);
            //foreach (Task task in georgeTask)
            //{
            //    Console.WriteLine($"Id :  {task.Id} - Nom :  {task.Name} - IdCat : {task.IdCategory} - IdPersonne : {task.IdPerson} \n- Description : {task.Descr} \n - Date de Creation : {task.CreationDate} - Date de fin prévue : {task.EndingDateMax} - Date de fin réel : {task.EndingDate}");
            //} 
            //#endregion

            //#region GetIcompleteTask
            //IEnumerable<Task> incompleteTask = taskServ.GetTasksIncomplete();
            //foreach (Task task in incompleteTask)
            //{
            //    Console.WriteLine($"Id :  {task.Id} - Nom :  {task.Name} - IdCat : {task.IdCategory} - IdPersonne : {task.IdPerson} \n- Description : {task.Descr} \n - Date de Creation : {task.CreationDate} - Date de fin prévue : {task.EndingDateMax} ");
            //} 
            //#endregion

            //#region AddTask
            //Task trainingADO = new Task()
            //{
            //    Id = 0,
            //    Name = "S'entrainer ",
            //    IdCategory = 1001,
            //    IdPerson = 1,
            //    Descr = "Faire de l'ADO",
            //    CreationDate = DateTime.Now,
            //    EndingDateMax = new DateTime(2022, 7, 2),

            //};
            //taskServ.AddTask(trainingADO); 
            //#endregion

            //#region UpdateTask
            //Task taskToUpdate = taskServ.GetById(1001);
            //taskToUpdate.Descr = "Faire de l'ADO à dos de chameau";
            //taskServ.UpdateTask(taskToUpdate); 
            //#endregion

            //#region DelTask
            //Task taskToDel = taskServ.GetById(1001);
            //taskServ.DeleteTask(taskToDel);
            //#endregion


        }
    }
}
