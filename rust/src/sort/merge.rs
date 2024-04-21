fn merge(list: &mut Vec<i32>) {
    let n = list.len();
    if n <= 1 {
        return;
    }
    let mid = n / 2;
    let mut left = list[..mid].to_vec();
    let mut right = list[mid..].to_vec();
    merge(&mut left);
    merge(&mut right);

    let mut Ileft = 0;
    let mut Iright = 0;
    let mut Icurrent = 0;

    while Ileft < left.len() && Iright < right.len() {
        if left[Ileft] < right[Iright] {
            list[Icurrent] = left[Ileft];
            Ileft += 1;
        } else {
            list[Icurrent] = right[Iright];
            Iright += 1;
        }
        Icurrent += 1;
    }

    while Ileft < left.len() {
        list[Icurrent] = left[Ileft];
        Ileft += 1;
        Icurrent += 1;
    }
    while Iright < left.len() {
        list[Icurrent] = left[Iright];
        Iright += 1;
        Icurrent += 1;
    }
}
