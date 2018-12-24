import { readFileSync } from "fs";
import { Computer } from "./Computer";

describe('Part two', () => {
    it('should calculate value in registers 0 after running test program', () => {
        const computer = new Computer()
        const input = readFileSync('input.txt').toString().split('\n')
        const { samples, program }  = computer.readInput(input);
        const opcodes = computer.determineOpcodes(samples);
        const result = computer.runProgram(opcodes, program);
        expect(result[0]).toEqual(575)
    })
})
