import { expect, test } from 'vitest'
import AddPlusOne from '@/plus'
test('adds 1 + 2 to equal 3', () => {
    expect(AddPlusOne(3)).toBe(3)
})



