using ReactASPCrud.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System;

namespace ReactASPCrud.Services
{
    public class ListService
    {
        private static List<TodoList> lists = new List<TodoList>();

        public IMongoCollection<TodoList> ConnectMongoDB()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=mongodb-vscode%200.6.14&ssl=false");
            var database = client.GetDatabase("todolist");
            var collection = database.GetCollection<TodoList>("list");

            return collection;
        }

        public List<TodoList> GetAll()
        {
            var collection = ConnectMongoDB();
            lists = collection.Find(_ => true).ToList();

            return lists.ToList();
        }
        public TodoList GetById(int id)
        {
            return null;
        }
        public TodoList Create(TodoList list)
        {
            var collection = ConnectMongoDB();
            collection.InsertOne(list);

            lists.Add(list);
            return list;
        }
        public void Update(int id, TodoList list)
        {

        }
        public List<TodoList> Delete(int id)
        {
            var collection = ConnectMongoDB();
            collection.DeleteOne(x => x.Id == id);

            lists.RemoveAll(n => n.Id == id);
            return lists;
        }
    }
}