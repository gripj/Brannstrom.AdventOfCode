using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day19
{
    public class MoleculeMachine
    {
        private static int _iterations;
        private readonly IEnumerable<ReplacementInstruction> _replacementInstructions;

        public MoleculeMachine(IEnumerable<ReplacementInstruction> replacementInstructions)
        {
            _replacementInstructions = replacementInstructions;
        }

        public int GetAmountOfDistinctModules(string molecule)
        {
            var createdMolecules = new List<string>();

            foreach (var replacementInstruction in _replacementInstructions)
            {
                var molecules = CreateMolecules(molecule, replacementInstruction);
                createdMolecules.AddRange(molecules);
            }
 
            return createdMolecules.Distinct().Count();
        }

        private static IEnumerable<string> CreateMolecules(string baseMolecule, ReplacementInstruction instruction)
        {
            var createdMolecules = new List<string>();
            var currentIndex = 0;

            currentIndex = baseMolecule.IndexOf(instruction.From, StringComparison.Ordinal);

            while (currentIndex != -1)
            {
                var molecule = baseMolecule.Remove(currentIndex, instruction.From.Length);
                createdMolecules.Add(molecule.Insert(currentIndex, instruction.To));
                currentIndex = baseMolecule.IndexOf(instruction.From, currentIndex + 1, StringComparison.Ordinal);
            }

            return createdMolecules;
        }

        public int GetStepsNeededToMakeMolecule(string startingMolecule, string goalMolecule, int step = 1)
        {
            _iterations++;

            if (!ShouldContinue)
                return int.MaxValue;

            var molecules = ReverseMolecule(goalMolecule).ToList();

            return IterateWithNewMolecules(molecules, startingMolecule, step);
        }

        private static bool ShouldContinue => _iterations < 100000;

        private IEnumerable<string> ReverseMolecule(string molecule)
        {
            var createdMolecules = new List<string>();

            foreach (var replacement in _replacementInstructions.Select(x => new ReplacementInstruction(x.To, x.From)))
                createdMolecules.AddRange(CreateMolecules(molecule, replacement));

            return createdMolecules;
        }

        private int IterateWithNewMolecules(IEnumerable<string> molecules, string startingMolecule, int currentStep)
        {
            if (molecules.Any(m => m == startingMolecule))
                return currentStep;

            if (!molecules.Any())
                return int.MaxValue;

            return molecules
                .Distinct()
                .Select(molecule =>
                    GetStepsNeededToMakeMolecule(startingMolecule, molecule, currentStep + 1))
                .ToList()
                .Min();
        }
    }
}
