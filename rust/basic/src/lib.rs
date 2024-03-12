mod basic_data;
pub fn add(left: usize, right: usize) -> usize {
    left + right
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn it_works() {
        let result = add(2, 2);
        assert_eq!(result, 4);
    }

    #[test]
    fn test_plus_one() {
        let number = basic_data::plus_one(2);
        assert_eq!(number, 4);
    }
}
