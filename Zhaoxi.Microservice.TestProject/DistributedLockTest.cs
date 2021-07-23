using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zhaoxi.AgilityFramework.ConsulClientExtend;

namespace Zhaoxi.Microservice.TestProject
{
    public class DistributedLockTest
    {
        public static void Show(string port)
        {
            IConsulIDistributed consulIDistributed = new ConsulIDistributed($"http://39.96.82.51:{port}/");
            //IConsulIDistributed consulIDistributed = new ConsulIDistributed($"http://localhost:{port}/");
            consulIDistributed.KVShow();

            for (int i = 0; i < 10; i++)
            {
                int k = i;
                Console.WriteLine($"Start  out {k}");
                Task.Run(() =>
                {
                    Console.WriteLine($"Start  in {k}");
                    consulIDistributed.ExecuteLocked("Eleven", new Action(() =>
                    {
                        Console.WriteLine($"This is UserController-Get-{k} Start");
                        Thread.Sleep(new Random().Next(100, 999));
                        //Thread.Sleep(new Random().Next(1100, 9999));
                        Console.WriteLine($"This is UserController-Get-{k}   End");
                    }));
                });
            }


            #region 另一种方式   AcquireLock 然后  IsHeld  最后Release
            {
                //for (int i = 0; i < 10; i++)
                //{
                //    int k = i;
                //   await Task.Run(async () =>
                //    {
                //        //var disLock = this._IConsulIDistributed.AcquireLock($"Eleven{this._IConfiguration["port"]}");
                //        var disLock = this._IConsulIDistributed.AcquireLock($"Eleven");//分布式锁
                //        //await disLock;
                //        var l = await disLock.ConfigureAwait(false); ;
                //        try
                //        {
                //            if (!l.IsHeld)
                //            {
                //                throw new Exception("Could not obtain the lock");
                //            }
                //            this._logger.LogInformation($"This is UserController-Get-{this._IConfiguration["port"]} {k} Start");
                //            //Thread.Sleep(new Random().Next(100, 999));
                //            Thread.Sleep(new Random().Next(1100, 9999));
                //            this._logger.LogInformation($"This is UserController-Get-{this._IConfiguration["port"]} {k}   End");
                //        }
                //        finally
                //        {
                //            await l.Release().ConfigureAwait(false);
                //            //disLock.Result.Release();
                //        }
                //    });
                //}
            }
            #endregion
        }
    }
}
