// TODO: Implement
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UiS.Dat240.Lab1.Queues;
using UiS.Dat240.Lab1.Commands;

Console.WriteLine("Trans rights!");
Console.WriteLine("Gay rights!");
Console.Write("Be gay");
Console.WriteLine(" do crime");
ArrayList al = new ArrayList();
         
         Console.WriteLine("Adding some numbers:");
         al.Add(45);
         al.Add(78);
         al.Add(33);
         al.Add(56);
         al.Add(12);
         al.Add(23);
         al.Add(9);
         
         Console.WriteLine("Capacity: {0} ", al.Capacity);
         Console.WriteLine("Count: {0}", al.Count);
         
         Console.Write("Content: ");
         foreach (int i in al) {
            Console.Write(i + " ");
         }

while (true){
Console.WriteLine("Write something: ");
string input = Console.ReadLine();
string[] commands = {"add", "rem", "size", "exit"};
Queue<string> queue = new Queue<string>();

foreach (var command in commands){
    if (input.Contains(command)){
        string[] subs = input.Split(command);
        if (input == "exit"){
            return;

        }
        
        else if (command == "add"){
            foreach (var sub in subs){
                Console.WriteLine($"You wrote: {sub}");
                queue.Enqueue(sub);
                
            }
           
        }
        else if(command == "rem"){
            Console.WriteLine("You wrote the remove command");
            if (queue.Count != 0){
                string value = queue.Dequeue();
                Console.WriteLine(value);
        }

            else{
                Console.WriteLine("The queue is empty");
            }
        }
        else if (command == "size"){
            int size = queue.Count;
            Console.WriteLine("The queue has size: " + size);
        }
        
        else{
            Console.WriteLine("You need to write a command: add | rem | size | exit");
        }
        }
    
}
}


public class StringQueue : IStringQueue
{
    string[] arrayL = new string [4];
    int capacity = 4;
    int index = 0;

    public int Length { 
        get;
    }
        
    public void Enqueue(string value)
    {
        if (capacity == index){
            Grow();
            index+= 1;
            arrayL[index] = value;           
            
        }
        
            //throw new NotImplementedException();
        
    }
    public string Dequeue()
    {
       if (index > 0)
        {
            for (int i = 0; i < index - 1; i++)
            {

                arrayL[i] = arrayL[i + 1];
            }
            
            arrayL[index - 1] = null;
            index--;
            return arrayL[0];
        }
        else{
            throw new Exception("The queue is empty");
        }
         
    }
    public void Grow(){
        
        string[] array2 = null;
        
        array2 = new string[capacity*2];
        for (int i = 0; i < capacity; i++)
            {
                array2[i] = arrayL[i];
            }
        capacity *=2;
            
        }
    
}




public class ObjectQueue : IObjectQueue
{
    object[] arrayL = new object [4];
    int capacity = 4;
    int index = 0;

    public int Length { 
        get;
    }
        
    public void Enqueue(object value)
    {
        if (capacity == index){
            Grow();
            index+= 1;
            arrayL[index] = value;           
            
        }
        
            //throw new NotImplementedException();
        
    }
    public object Dequeue()
    {
       if (index > 0)
        {
            for (int i = 0; i < index - 1; i++)
            {

                arrayL[i] = arrayL[i + 1];
            }
            
            arrayL[index - 1] = null;
            index--;
            return arrayL[0];
        }
        else{
            throw new Exception("The queue is empty");
        }
         
    }
    public void Grow(){
        
        object[] array2 = null;
        
        array2 = new object[capacity*2];
        for (int i = 0; i < capacity; i++)
            {
                array2[i] = arrayL[i];
            }
        capacity *=2;
            
        }
    
}


// public class StringQueue : ObjectQueue
// {
//     string[] arrayL = new string [4];
//     int capacity = 4;
//     int index = 0;

//     public int Length { 
//         get;
//     }
        
//     public void Enqueue(string value)
//     {
//         ObjectQueue.Enqueue()
//     }
//     public string Dequeue()
//     {
//        if (index > 0)
//         {
//             for (int i = 0; i < index - 1; i++)
//             {

//                 arrayL[i] = arrayL[i + 1];
//             }
            
//             arrayL[index - 1] = null;
//             index--;
//             return arrayL[0];
//         }
//         else{
//             throw new Exception("The queue is empty");
//         }
         
//     }
//     public void Grow(){
        
//         string[] array2 = null;
        
//         array2 = new string[capacity*2];
//         for (int i = 0; i < capacity; i++)
//             {
//                 array2[i] = arrayL[i];
//             }
//         capacity *=2;
            
//         }
    
// }

public class GenericQueue<T> : IGenericQueue<T>
{
    private T[] arrayL = new T[4];
    int capacity = 4;
    int index = 0;

    public int Length { 
        get;
    }
        
    public void Enqueue(T value)
    {
        if (capacity == index){
            Grow();
            index+= 1;
            arrayL[index] = value;           
            
        }
        
            //throw new NotImplementedException();
        
    }
    public T Dequeue()
    {
       if (index > 0)
        {
            for (int i = 0; i < index - 1; i++)
            {

                arrayL[i] = arrayL[i + 1];
            }
            
            arrayL[index - 1] = default(T);
            index--;
            return arrayL[0];
        }
        else{
            throw new Exception("The queue is empty");
        }
         
    }
    public void Grow(){
        
        T[] array2 = null;
        
        array2 = new T[capacity*2];
        for (int i = 0; i < capacity; i++)
            {
                array2[i] = arrayL[i];
            }
        capacity *=2;
            
        }

    T IGenericQueue<T>.Dequeue()
    {
        throw new NotImplementedException();
    }
}



// public class AddHandler : ICommandHandler
// {
//   // The name of the command
//   public string Name => "CommandName";
//   // Since we are going to register the AddHandler in the dependency injection, 
//   // then we can request other service from DI in constructor parameters.
//   public AddHandler(IStringQueue stringQueue)
//   {
//     // The request service should also be stored and used later in the class
//   }

//   // The function to be executed when the user write the command name
//   public void Handle(string args)
//   {
//     var collection = new ServiceCollection();
//     var provider = collection.BuildServiceProvider(true);
//     provider.GetServices<ICommandHandler>();
    
//     var content = Console.ReadLine();
//     if (content == "exit"){
//         return;
//     }



//   }
// }