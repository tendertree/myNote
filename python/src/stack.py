from typing import List


def execute(program: List[str]) -> List[int]:
    # initialize the stack
    stack = [1, 2, 3, 4, 5, 6, 7]
    for instruction in program:
        if instruction == "peek":
            # print out the top item in stack
            if stack:
                print(stack[-1])
            else:
                print("Stack is empty!")
        elif instruction == "pop":
            # pop the top item in stack
            if stack:
                stack.pop()
            else:
                print("Cannot pop from an empty stack!")
        else:
            if instruction.startswith("push"):
                try:
                    data = int(instruction[5:])
                    stack.append(data)
                except ValueError:
                    print(f"Invalid data format: {instruction[5:]}")
            else:
                print(f"Invalid instruction: {instruction}")

    return stack


if __name__ == "__main__":
    try:
        num_instructions = int(input("Enter the number of instructions: "))
        program = [input(f"Instruction {i+1}: ") for i in range(num_instructions)]
        res = execute(program)
        print(" ".join(map(str, res)))
    except ValueError:
        print("Invalid number of instructions!")
