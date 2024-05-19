function get_neighbors(node) {
    return node;
}
function bfs(root) {
    let q = [root];
    let visited = new Set([root]);
    while (q.length > 0) {
        const node = q.shift();
        for (const neighbor of get_neighbors(node)) {
            if (visited.has(neighbor)) continue;
            q.push(neighbor);
            visited.add(neighbor);
        }
    }
}
