def plusOne(number):
    return number + 1


import unittest


class TestBasicData(unittest.TestCase):
    def test_plusOne(self):
        self.assertEqual(plusOne(1), 3)


if __name__ == "__main__":
    unittest.main()
