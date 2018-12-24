export class Computer {
    evaluateSamples(samples: any) {
        let numberOfSamples = 0;
    
        for (let sample of samples) {
            const { before, instructions, after } = sample;
            const opcodes = Object.values(this.operations)
                .map((op: any) => op(instructions)(before))
                .filter((result: any) => result.toString() === after.toString()).length;
    
            if (opcodes >= 3) numberOfSamples += 1;
        }
        return numberOfSamples;
    }

    determineOpcodes(samples: any) {   
        const opcodes = [] as any;
        const remainingOperations = new Map(Object.entries(this.operations));
        let i = 0;
        while (remainingOperations.size > 0) {

            const { before, instructions, after } = samples[i];

            const candidates = [...remainingOperations]
                .map(([name, op]) => ({
                    name,
                    op,
                    result: (op as Function)(instructions)(before)
                }))
                .filter(({ result }) => result.toString() === after.toString());
    
            if (candidates.length === 1) {
                const { name, op } = candidates[0];
    
                const opcode = instructions[0];
                opcodes[opcode] = op;
                remainingOperations.delete(name);

                samples = samples.filter(({ instructions } : { instructions: any}) => instructions[0] !== opcode);
                i = 0;
            }
    
            i = (i + 1) % samples.length;
        }
        return opcodes;
    }

    runProgram = (opcodes: any, program: any) => {
        let result = [0, 0, 0, 0];
        for (const instruction of program) {
            const op = opcodes[instruction[0]];
            result = op(instruction)(result);
        }
        return result;
    }

    readInput = (lines: any) => {
        const beforeRegex = /^Before: \[(?<b0>\d), (?<b1>\d), (?<b2>\d), (?<b3>\d)\]$/;
        const instructionRegex = /^(?<op>\d+) (?<a>\d) (?<b>\d) (?<c>\d)$/;
        const afterRegex = /^After:  \[(?<a0>\d), (?<a1>\d), (?<a2>\d), (?<a3>\d)\]$/;
        const samples = [] as any;
        const program = [] as any;
        const n = lines.length;
        for (let i = 0; i < n; i++) {
            const line = lines[i];
            const sampleMatch = line.match(beforeRegex);
            if (sampleMatch) {
                const { b0, b1, b2, b3 } = sampleMatch.groups;
                const { op, a, b, c } = lines[i+1].match(instructionRegex).groups;
                const { a0, a1, a2, a3 } = lines[i+2].match(afterRegex).groups;
                samples.push({
                    before: [+b0, +b1, +b2, +b3],
                    instructions: [+op, +a, +b, +c],
                    after: [+a0, +a1, +a2, +a3]
                });
                i += 2;
            }
            else {
                const programMatch = line.match(instructionRegex);
                if (programMatch) {
                    const { op, a, b, c } = programMatch.groups;
                    program.push([+op, +a, +b, +c]);
                }
            }

        }
        return { samples, program };
    };

    operations = {
        'addr': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] + registers[b]; 
            return result; 
        },
        'addi': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] + b;
            return result; 
        },
        'mulr': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] * registers[b]; 
            return result; 
        },
        'muli': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] * b; 
            return result; 
        },
        'banr': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] & registers[b]; 
            return result; 
        },
        'bani': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] & b; 
            return result; 
        },
        'borr': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] | registers[b]; 
            return result; 
        },
        'bori': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] | b; 
            return result; 
        },
        'setr': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a]; 
            return result; 
        },
        'seti': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = a; 
            return result; 
        },
        'gtir': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = a > registers[b] ? 1 : 0; 
            return result; 
        },
        'gtri': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] > b ? 1 : 0; 
            return result; 
        },
        'gtrr': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] > registers[b] ? 1 : 0; 
            return result; 
        },
        'eqir': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = a === registers[b] ? 1 : 0; 
            return result; 
        },
        'eqri': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] === b ? 1 : 0; 
            return result; 
        },
        'eqrr': ([op, a, b, c]) => registers => { 
            const result = [...registers];
            result[c] = registers[a] === registers[b] ? 1 : 0;
            return result;
        }
    };
}
