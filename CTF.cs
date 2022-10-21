/* 
----------------------
My first ever App CTF
    Network based
    -------------
    - Daegatoya -
                    */

namespace CTF
{
    /* Defining what modules we will be using. */
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;

    /* Defining the default authorization level. */
    public class Define
    {
        public int auth_Lvl = 0;
    }

  class Main_Class
    {
        public static void Program(string user_IP, string network_Mask, string answer, string subnet_Mask, string user_IPv6, string network_Mask2)
        {
            
            /* Declaration of variables. */
            Define Variables = new Define();
            int authorization = Variables.auth_Lvl;
            string rank;
            string case_1 = network_Mask + "2c75:7d0c::";
            string case_2 = network_Mask2 + "100";
            string message;
            string user_Name = Environment.UserName;
            bool perm_Check = false;
            string read_Line;

            /* Create a switch case with the IPv6 of the user. */
            switch (user_IPv6)
            {
                    /* If the IPv6 corresponds to the admin's IPv6, then... */
                case var value when value == case_1:
                    
                    /* If the IPv4 corresponds to the admin's IPv4, then... */
                    if(user_IP == case_2)
                        
                        /* Give admin authorization. */
                        authorization = 4;
                    break;

                    /* If one of them doesn't correspond, then... */
                default:
                    authorization = 0;
                    break;
            }

            /* Create a switch case with the authorization level. */
            switch (authorization)
            {
                    /* Defining the rank of the user based on their authorization level. */
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
            
            /* Print the opening message. */
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

            /* Create a loop to run infinite commands. */
            for (int j = 1; j > 0;)
            {
                Console.WriteLine("\nEnter the command to execute below:");

                read_Line = Console.ReadLine();
                
                /* If the command is answer_Give, then... */
                if (read_Line != null && read_Line == "answer_Give")
                {
                    if (perm_Check)
                    {
                        
                        /* If the user has admin authorization, gives out the flag. */
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\tFLAG{{{answer}}}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPlease, take a screenshot of the answer, as it is a random generated string.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        
                        /* If user doesn't have admin authorization, denies the request. */
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tPermission denied. Authorization level 4 required.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                
                /* If the command is IPv4_Check, then... */
                else if (read_Line != null && read_Line == "IPv4_Check")
                {
                    
                    /* Prints out the current local IPv4 address of the user's network. */
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n\tThe current IPv4 in use is: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{user_IP}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                /* If the command is IPv6_Check, then... */
                else if (read_Line != null && read_Line == "IPv6_Check")
                {
                    
                    /* Prints out the current local IPv6 address of the user's network. (If none, prints that no IPv6 is in use.) */
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n\tThe current IPv6 in use is: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{user_IPv6}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                /* If the command is subnet_Check, then... */
                else if (read_Line != null && read_Line == "subnet_Check")
                {
                    
                     /* Prints out the current local subnet mask of the user's network. */
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"\n\tThe current subnet mask in use is: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{subnet_Mask}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                /* If the command is ? or help, then... */
                else if (read_Line != null && read_Line == "?" || read_Line != null && read_Line == "help")
                {
                    
                    /* Prints a list of the available commands. */
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\tAvailable commands:\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"IPv4_Check\nIPv6_Check\nanswer_Give\nranks_List\nadmin_IP\nexit\nranks_Up\nranks_Check\nsubnet_Check");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                /* If the command is ranks_Check, then... */
                else if (read_Line != null && read_Line == "ranks_Check")
                {
                    
                    /* Gives out the current user's rank. */
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
                
                /* If the command is ranks_List, then... */
                else if (read_Line != null && read_Line == "ranks_List")
                {
                    
                    /* Prints a list of the existing ranks. */
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tRanks list <Rank (AuthLvl)>:\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Guest (0)\nMember (1)\nV.I.P (2)\nModerator (3)\nAdministrator (4)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                /* If the command is ranks_Up, then... */
                else if (read_Line != null && read_Line == "ranks_Up")
                {
                    
                    /* If the authorization level is below 3, then... */
                    if (authorization < 3)
                    {
                        
                        /* The user gains 1 rank and 1 authorization level. */
                        authorization++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n\tYour new rank is: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        
                        /* Sets the new rank of the user. */
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
                        
                        /* Prints the final message. */
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" with authorization level of: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(authorization);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                    /* If the authorization level is 3, then... */
                    else if (authorization == 3)
                    {
                        
                        /* Denies the request and say that the user cannot rank higher. */
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nSorry, but you cannot rank higher than Moderator.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                    /* If the authorization level is 4, then... */
                    else if (authorization == 4)
                    {
                        
                        /* Denies the request and specifies that the user is already an administrator. */
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nYou are already an Administrator.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                
                /* If the command is admin_IP, then... */
                else if (read_Line != null && read_Line == "admin_IP")
                {
                    
                    /* Prints the expected IPv6 and IPv4 that the admin network should have. */
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\t[IPv6_Prefix{true}]2c75:7d0c:0:0:0:0:0\n\t[subnet_Mask{true}].100");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
                /* If the command is exit, then... */
                else if (read_Line != null && read_Line == "exit")
                {
                    
                    /* Exit the program with code 1. */
                    Environment.Exit(0x1);
                }
                
                /* If the command is unknown, then... */
                else
                {
                    
                    /* Denies the request. */
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tUnknown command.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        static void Main()
        {
            
            /* Declaration of the Main variables. */
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

            /* Check the IPv4 of the user according to the in-use network. */
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

            /* Check the IPv6 of the user according to the in-use network. */
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
                        
                        /* If the user has no active IPv6, put it as unknown. */
                        IPv6 = "No IPv6 detected.";
                    }
                }
            }

            /* If the IPv6 is not unknown, then... */
            if (IPv6 != "No IPv6 detected.")
            {
                
                /* Trimming the IPv6 to only get some parts of it. */
                string[] network = IPv6.Split(':');
            List<string> net_List = new List<string>(network);
            net_List.RemoveAt(1);
            net_List.RemoveAt(1);
            net_List.RemoveAt(2);
            network = net_List.ToArray();
            network[0] = network[0] + ":";
            check = String.Concat(network);
        }

            /* Trimming the IPv4 to only get some parts of it. */
                string[] network2 = IPv4.Split('.');
                List<string> net_List2 = new List<string>(network2);
                net_List2.RemoveAt(3);
                network2 = net_List2.ToArray();
                for(int k = 0; k < network2.Length; k++)
            {
                network2[k] = network2[k] + ".";
            }
                check2 = String.Concat(network2);

            /* Generating the random flag consisting of 10 letters. */
            for (int i = 0; i < r_Lenght; i++)
            {

                value = r.Next(0, 26);

                letter = Convert.ToChar(value + 65);

                answer_String = answer_String + letter;
            }

            /* Checking the current subnet mask according to the in-use network. */
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

            /* Launches the program with the correct informations to proceeds it. */
                Program(IPv4, check, answer_String, mask, IPv6, check2);
        }
    }
}
