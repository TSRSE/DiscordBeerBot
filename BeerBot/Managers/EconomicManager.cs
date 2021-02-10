using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using System.IO;
using System.Threading.Tasks;

namespace BeerBot_1
{
    class EconomicManager
    {
        public UInt64 MoneyGet(DiscordMember member)
        {
            UInt64 totalamount = 0;
            if (File.Exists($@"Stats\{member.Username}.txt"))
            {
                totalamount = UInt64.Parse(File.ReadAllText($@"Stats\{member.Username}.txt"));
            }
            else
            {
                File.WriteAllText($@"Stats\{member.Username}.txt", "500");
                totalamount = UInt64.Parse(File.ReadAllText($@"Stats\{member.Username}.txt"));
            }
            return totalamount;
        }

        public bool MoneyDes(DiscordMember member, int amount)
        {
            int totalamount = 0;
            if (File.Exists($@"Stats\{member.Username}.txt"))
            {
                totalamount = int.Parse(File.ReadAllText($@"Stats\{member.Username}.txt"));
            }
            else
            {
                File.WriteAllText($@"Stats\{member.Username}.txt", "500");
                totalamount = int.Parse(File.ReadAllText($@"Stats\{member.Username}.txt"));
            }

            if (totalamount - amount >= 0)
            {
                totalamount = totalamount - amount;
                File.WriteAllText($@"Stats\{member.Username}.txt", totalamount.ToString());
                return true;
            }
            else
                return false;
            
        }

        public void MoneyAdd(DiscordMember member, int amount)
        {
            int totalamount = 0;
            if (File.Exists($@"Stats\{member.Username}.txt"))
            {
                totalamount = int.Parse(File.ReadAllText($@"Stats\{member.Username}.txt"));
            }
            else
            {
                File.WriteAllText($@"Stats\{member.Username}.txt", "500");
                totalamount = int.Parse(File.ReadAllText($@"Stats\{member.Username}.txt"));
            }
            totalamount = totalamount + amount;
            File.WriteAllText($@"Stats\{member.Username}.txt", totalamount.ToString());
        }

        public List<MyTopUsers> GetUsersFromFiles()
        {
            List<MyTopUsers> Users = new List<MyTopUsers>();
            DirectoryInfo dir = new DirectoryInfo(@"Stats");
            foreach (var item in dir.GetDirectories())
            {
                int money = int.Parse(File.ReadAllText($@"Stats\{item.Name}"));
                Users.Add(new MyTopUsers(item.Name, money));
            }
            return Users;
        }
    }
}
