using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace arduino.Hubs
{
    public class EventHub : Hub
    {



    //    public string MethodOneSimpleParameterSimpleReturnValue(string p1)
    //    {
    //        Console.WriteLine($"'MethodOneSimpleParameterSimpleReturnValue' invoked. Parameter value: '{p1}");


    //        using (StreamWriter writer = System.IO.File.AppendText("logfilssdse.txt"))
    //        {
    //            writer.WriteLine("get Sate  :  " + DateTime.Now.ToString());
    //        }
    //        return p1;
    //    }

    //    public async Task getSate(string StateKey)
    //    {

    //        try
    //        {
    //            using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
    //            {
    //                writer.WriteLine("get Sate  :  " + DateTime.Now.ToString());
    //            }

    //            await Clients.All.SendAsync("aClientProvidedFunction", null);
    //            await Clients.All.SendAsync("getSate", StateKey);
    //        }
    //        catch (Exception ex)
    //        {
    //            using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
    //            {
    //                writer.WriteLine("exxx  :  " + ex.ToString() + " " + DateTime.Now.ToString());
    //            }


    //        }

    //    }

    //    public async Task fromclient(string StateKey)
    //    {


    //        try
    //        {


    //            using (StreamWriter writer = System.IO.File.AppendText("fromclient.txt"))
    //            {
    //                writer.WriteLine("fromclient  :  " + DateTime.Now.ToString());
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            using (StreamWriter writer = System.IO.File.AppendText("fromclient.txt"))
    //            {
    //                writer.WriteLine("exxx  :  " + ex.ToString() + " " + DateTime.Now.ToString());
    //            }


    //        }

    //    }


    //    public async Task fromserver(string StateKey)
    //    {


    //        try
    //        {


               
    //            await Clients.All.SendAsync("fromserver", "sdasadsa");
    //            using (StreamWriter writer = System.IO.File.AppendText("fromserver.txt"))
    //            {
    //                writer.WriteLine("fromserver  :  " + DateTime.Now.ToString());
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            using (StreamWriter writer = System.IO.File.AppendText("fromserver.txt"))
    //            {
    //                writer.WriteLine("exxx  :  " + ex.ToString() + " " + DateTime.Now.ToString());
    //            }


    //        }

    //    }


    //    public async Task poooo(string StateKey)
    //    {


    //        try
    //        {

    //            var Cleint = Clients.All;
    //            using (StreamWriter writer = System.IO.File.AppendText("pooo.txt"))
    //            {
    //                writer.WriteLine("pooo  :  " + DateTime.Now.ToString());
    //            }
    //            await Clients.Others.SendAsync("poooo", "sdasadsa");
    //        }
    //        catch (Exception ex)
    //        {
    //            using (StreamWriter writer = System.IO.File.AppendText("logfile.txt"))
    //            {
    //                writer.WriteLine("exxx  :  " + ex.ToString() + " " + DateTime.Now.ToString());
    //            }


    //        }

    //    }
    }

}

