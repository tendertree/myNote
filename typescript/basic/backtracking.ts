/*
 * return aa, ab, ba, bb...
 */
export function FindPermutationsAB(
    n: number,
    res: string[],
    s: number,
    path: string[],
) {
    if (s == n) {
        res.push(path.join(""));
        return;
    }
    ["a", "b"].forEach((letter) => {
        path.push(letter);
        FindPermutationsAB(n, res, s + 1, path);
        path.pop();
    });
}
