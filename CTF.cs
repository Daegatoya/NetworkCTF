namespace CTF
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;

    public class Define
    {
        public int auth_Lvl = 0;
    }

  class Main_Class
    {
        public static void Program(string user_IP, string network_Mask, string answer, string subnet_Mask, string user_IPv6, string network_Mask2)
        {
            Define Variables = new Define();
            int authorization = Variables.auth_Lvl;
            string rank;
            string case_1 = network_Mask + "2c75:7d0c::";
            string case_2 = network_Mask2 + "100";
            string message;
            string user_Name = Environment.UserName;
            bool perm_Check = false;
            string read_Line;

            switch (user_IPv6)
            {
                case var value when value == case_1:
                    if(user_IP == case_2)
                        authorization = 4;
                    break;

                default:
                    authorization = 0;
                    break;
            }

            switch (authorization)
            {
                case 1:
                    rank = "Member";
                    message = "Welcome, " + user_Name;
                    break;

                case 2:
                    rank = "V.I.P";
                    message = "Welcome, " + user_Name;
                    break;

                case 3:
                    rank = "Moderator";
                    message = "Welcome, " + user_Name;
                    break;

                case 4:
                    rank = "Administrator";
                    message = "Welcome, " + user_Name;
                    perm_Check = true;
                    break;

                default:
                    rank = "Guest";
                    message = "Welcome, " + user_Name;
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\tYou currently uphold the rank of: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(rank);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" with authorization level of: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(authorization);
            Console.ForegroundColor = ConsoleColor.White;

            for (int j = 1; j > 0;)
            {
                Console.WriteLine("\nEnter the command to execute below:");

                read_Line = Console.ReadLine();
                if (read_Line != null && read_Line == "answer_Give")
                {
                    if (perm_Check)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\tFLAG{{{answer}}}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPlease, take a screenshot of the answer, as it is a random generated string.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tPermission denied. Authorization level 4 required.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (read_Line != null && read_Line == "IPv4_Check")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n\tThe current IPv4 in use is: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{user_IP}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (read_Line != null && read_Line == "IPv6_Check")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n\tThe current IPv6 in use is: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{user_IPv6}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (read_Line != null && read_Line == "subnet_Check")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n\tThe current subnet mask in use is: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{subnet_Mask}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (read_Line != null && read_Line == "?" || read_Line != null && read_Line == "help")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tAvailable commands:\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"IPv4_Check\nIPv6_Check\nanswer_Give\nranks_List\nadmin_IP\nexit\nranks_Up\nranks_Check\nsubnet_Check");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (read_Line != null && read_Line == "ranks_Check")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\tYou currently uphold the rank of: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(rank);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" with authorization level of: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(authorization);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (read_Line != null && read_Line == "ranks_List")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tRanks list <Rank (AuthLvl)>:\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Guest (0)\nMember (1)\nV.I.P (2)\nModerator (3)\nAdministrator (4)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (read_Line != null && read_Line == "ranks_Up")
                {
                    if (authorization < 3)
                    {
                        authorization++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\tYour new rank is: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (authorization == 1)
                        {
                            Console.Write("Member");
                            rank = "Member";
                        }
                        else if (authorization == 2)
                        {
                            Console.Write("V.I.P");
                            rank = "V.I.P";
                        }
                        else if (authorization == 3)
                        {
                            Console.Write("Moderator");
                            rank = "Moderator";
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" with authorization level of: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(authorization);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (authorization == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nSorry, but you cannot rank higher than Moderator.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (authorization == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nYou are already an Administrator.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (read_Line != null && read_Line == "admin_IP")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\t[IPv6_Prefix{true}]2c75:7d0c:0:0:0:0:0\n\t[subnet_Mask{true}].100");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (read_Line != null && read_Line == "exit")
                {
                    Environment.Exit(0x1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tUnknown command.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        static void Main()
        {
            string IPv4 = "";
            string IPv6 = "";
            string check = "";
            string check2 = "";
            Random r = new Random();
            int r_Lenght = 10;
            int value;
            string answer_String = "";
            char letter;
            string mask = "";

            IPHostEntry user_Host = default(IPHostEntry);
            string host_Name = System.Environment.MachineName;
            user_Host = Dns.GetHostEntry(host_Name);

            foreach (IPAddress IP in user_Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPv4 = Convert.ToString(IP);
                }
            }

            IPHostEntry host = default(IPHostEntry);
            string name = System.Environment.MachineName;
            host = Dns.GetHostEntry(name);

            foreach (IPAddress IP6 in host.AddressList)
            {
                if (IP6.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    IPv6 = Convert.ToString(IP6);
                    if (IPv6 == "::1")
                    {
                        IPv6 = "Aucune IPv6 détecté";
                    }
                }
            }

            if (IPv6 != "Aucune IPv6 détecté")
            {
                string[] network = IPv6.Split(':');
            List<string> net_List = new List<string>(network);
            net_List.RemoveAt(1);
            net_List.RemoveAt(1);
            net_List.RemoveAt(2);
            network = net_List.ToArray();
            network[0] = network[0] + ":";
            check = String.Concat(network);
        }

                string[] network2 = IPv4.Split('.');
                List<string> net_List2 = new List<string>(network2);
                net_List2.RemoveAt(3);
                network2 = net_List2.ToArray();
                for(int k = 0; k < network2.Length; k++)
            {
                network2[k] = network2[k] + ".";
            }
                check2 = String.Concat(network2);

            for (int i = 0; i < r_Lenght; i++)
            {

                value = r.Next(0, 26);

                letter = Convert.ToChar(value + 65);

                answer_String = answer_String + letter;
            }

            IPAddress address = IPAddress.Parse(IPv4);
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
                {
                    foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                    {
                        if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            if (address.Equals(unicastIPAddressInformation.Address))
                            {
                                mask = unicastIPAddressInformation.IPv4Mask.ToString();
                            }
                        }
                    }
                }

                Program(IPv4, check, answer_String, mask, IPv6, check2);
        }
    }
}
