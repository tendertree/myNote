fn split_words(s: &str) -> Vec<&str> {
    s.split_whitespace().collect::<Vec<&str>>()
}

fn main() {
    let words = split_words("hello world");

    for word in words {
        println!("{}", word);
    }
}
