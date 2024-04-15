use std::collections::{HashMap, HashSet};

fn alien_order(words: Vec<&str>) -> String {
    let mut graph: HashMap<char, HashSet<char>> = HashMap::new();

    // Build the graph
    for word in &words {
        for c in word.chars() {
            graph.entry(c).or_insert_with(HashSet::new);
        }
    }

    // Convert the HashSet into a Vec<char> for sorting
    let mut characters: Vec<char> = graph.keys().cloned().collect();
    characters.sort();

    // Build the result string
    let mut result = String::new();
    for c in characters {
        result.push(c);
    }

    result
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_alien_order() {
        // Test case 1: Basic test
        let words1 = vec!["word", "world", "hello"];
        assert_eq!(alien_order(words1), "zehlorw");

        // Test case 2: Empty input
        let words2: Vec<&str> = vec![];
        assert_eq!(alien_order(words2), "");

        // Test case 3: Input with single word
        let words3 = vec!["hello"];
        assert_eq!(alien_order(words3), "ehlo");

        // Add more test cases as needed
    }
}
