using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using PowerShell = System.Management.Automation.PowerShell;

namespace BoostBottonWpf
{

    class PowerShellHelper
    {
        readonly static string SCRIPT_PATH = @"./mypowerscript.ps1";

        InitialSessionState iss;
        Runspace rs;
        RunspaceInvoke runspaceInvoke;
        PowerShell ps;
        Pipeline pipeline;
        Command command1;

        List<InitialSessionState> sessionStates;
        List<SessionStateVariableEntry> sSVarEntries;
        List<Runspace> runspaces;
        List<PowerShell> pslist;

        List<dynamic> output;

        public PowerShellHelper()
        {

            iss = InitialSessionState.CreateDefault();
            sSVarEntries = new List<SessionStateVariableEntry>();
            sessionStates = new List<InitialSessionState>();
            output = new List<dynamic>();
            pslist = new List<PowerShell>();
            runspaces = new List<Runspace>();




        }


        public void RsOpen()
        {
            rs = RunspaceFactory.CreateRunspace(iss);
            rs.Open();
        }

        public void RsInvoke()
        {
            runspaceInvoke = new RunspaceInvoke(rs);

        }

        public void CreatePipline()
        {
            pipeline = rs.CreatePipeline();
        }

        public void RsClose()
        {
            if (rs != null)
                rs.Close();
        }

        public void CreatePowerShell()
        {
            ps = PowerShell.Create();
            if (rs != null)
            {
                ps.Runspace = rs;
            }
        }
        public void CreatePowerShells(PowerShell power)
        {



            pslist.Add(power);
            if (rs != null)
            {
                foreach (PowerShell p in pslist)
                {
                    p.Runspace = rs;

                }

            }
        }
        public void CreatePowerShells(PowerShell power, SessionStateVariableEntry session)
        {
            sessionStates.Add(InitialSessionState.CreateDefault());


            foreach (InitialSessionState s in sessionStates)
            {
                runspaces.Add(RunspaceFactory.CreateRunspace(iss));
            }



            pslist.Add(power);
            if (rs != null)
            {
                foreach (Runspace r in runspaces)
                {
                    foreach (PowerShell p in pslist)
                    {
                        p.Runspace = r;

                    }
                }

            }
            foreach (Runspace r in runspaces)
            {
                r.Open();
            }
        }

        public PowerShell GetPS
        {
            get
            {
                return ps;
            }
        }

        public List<PowerShell> GetPsList
        {
            get
            {
                return pslist;
            }
        }

        public void SynchronousPipline()
        {



            foreach (PSObject result in ps.Invoke())
            {
                if (result != null)
                {

                    //MessageBox.Show(result.BaseObject.ToString());

                }
            }
        }

        public void AysncAddCommand(string command, int pindex = 0)
        {
            if (ps != null)
            {
                ps.AddCommand(command);
            }



        }
        public void AysncAddCommand(string command, string arg, int pindex = 0)
        {



            if (ps != null)
            {
                ps.AddCommand(command);
                ps.AddArgument(arg);
            }





        }
        public void Clear()
        {
            if (Output != null)
            {
                output = new List<dynamic>();

            }
        }
        public void AysncAddCommand(string command, string arg, string param, int pindex = 0)
        {


            if (ps != null)
            {
                ps.AddCommand(command);
                ps.AddArgument(arg);
                ps.AddParameter(param);
            }



        }
        public void AysncAddCommand(string command, string arg, string param, object paramobject, int pindex = 0)
        {
            if (ps != null)
            {
                ps.AddCommand(command);
                ps.AddArgument(arg);
                ps.AddParameter(param, paramobject);
            }







        }
        public void AysncAddCommand(string command, string arg, IDictionary paramss, int pindex = 0)
        {

            if (ps != null)
            {
                ps.AddCommand(command);
                ps.AddArgument(arg);
                ps.AddParameters(paramss);
            }






        }
        public void AysncAddCommand(string command, string arg, IList paramss, int pindex = 0)
        {
            if (ps != null)
            {
                ps.AddCommand(command);
                ps.AddArgument(arg);
                ps.AddParameters(paramss);
            }






        }
        public void AysncAddScript(string script, int pindex = 0)
        {


            if (ps != null)
            {
                ps.AddScript(script);
            }







        }
        public void AysncAddScript(string script, bool localscope, int pindex = 0)
        {
            ps.AddScript(script, localscope);
            if (ps != null)
            {
                ps.AddScript(script, localscope);
            }






        }

        static int asynccount = 0;
        public void AysncSynchronousPipline(int who = 0)
        {

            if (ps != null)
            {
                IAsyncResult async = ps.BeginInvoke();

                ps.Runspace.Debugger.DebuggerStop += Debugger_DebuggerStop;





                foreach (PSObject result in ps.EndInvoke(async))
                {

                    if (result != null)
                    {
                        output.Add(result.BaseObject);


                    }



                }
            }






        }

        private void Debugger_DebuggerStop(object sender, DebuggerStopEventArgs e)
        {
            //Console.WriteLine(e);
        }

        public List<dynamic> Output
        {
            get
            {
                return output;
            }
        }



        public void Add(SessionStateVariableEntry session)
        {
            sSVarEntries.Add(session);
            iss.Variables.Add(sSVarEntries);


        }


    }
}
