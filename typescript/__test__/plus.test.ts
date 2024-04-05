import { expect, test } from 'vitest'
import AddPlusOne from '@/plus'
test('adds 1 + 2 to equal 3', () => {
	expect(AddPlusOne(5)).toBe(3)
})



