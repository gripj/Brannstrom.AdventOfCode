import { readFileSync } from "fs";
import { Computer } from "./Computer";

describe('Part One', () => {
    let computer: Computer

    beforeEach(() => {
        computer = new Computer()
    })

    it('Computer should calculate how many samples behave like three or more opcodes in example', () => {
        const input = [
            'Before: [3, 2, 1, 1]',
            '9 2 1 2',
            'After:  [3, 2, 2, 1]'
        ]
        const { samples } = computer.readInput(input);
        const numberOfSamples = computer.evaluateSamples(samples);
        expect(numberOfSamples).toBe(1)
    })

    it('Computer should calculate how many samples behave like three or more opcodes', () => {
        const input = readFileSync('input.txt').toString().split('\n')
        const { samples } = computer.readInput(input);
        const numberOfSamples = computer.evaluateSamples(samples);
        expect(numberOfSamples).toBe(542)
    })
})
