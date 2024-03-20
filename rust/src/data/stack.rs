fn stack(program: Vec<String>) -> Vec<i32> {
    let mut stack: Vec<i32> = Vec::new();
    for instruction in program {
        match instruction.as_str() {
            "peak" => {
                if let Some(&top) = stack.last() {
                    println!("{}", top);
                } else {
                    println!("Stack is Empty")
                }
            }
            "pop" => {
                if !stack.is_empty() {
                    stack.pop();
                } else {
                    println!("cannot pop from an empty")
                }
            }
            _ => {
                if instruction.starts_with("push") {
                    if let OK(data) = instruction[5..].parse::<i32>() {
                        stack.push(data);
                    } else {
                        println("invalid data format")
                    }
                } else {
                    println("invalid instruction")
                }
            }
        }
    }
    stack
}
fn main() {
    let mut program = Vec::new();
    let mut input = String::new();
    println!("enter the number");
    io::stdin()
        .read_line(&mut input)
        .expect("failed to read input");
    let num_instructions = input.trim().parse().expect("please enter a number");
}
