using System;
using System.Text;
using McMaster.Extensions.CommandLineUtils;

namespace OtterKeys
{
    [Command(
        Name = "OtterKeys",
        FullName = "OtterKeys the key pair creation tool",
        Description = "A command line utility to create new encryption key pairs."
    )]
    [Subcommand("new", typeof(Commands.NewCommand))]
    [Subcommand("recover", typeof(Commands.RecoverCommand))]
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var app = new CommandLineApplication<Program>
            {
                ThrowOnUnexpectedArgument = false
            };
            app.Conventions.UseDefaultConventions();

            if (args.Length == 0)
            {
                app.ShowHelp();
            }

            try
            {
                app.Execute(args);
            }
            catch (Exception)
            {
            }
        }

        private int OnExecute(CommandLineApplication app)
        {
            return 0;
        }
    }
}
