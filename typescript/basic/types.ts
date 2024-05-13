/*
 * list내에 모든 타입이 Texpected 타입을 만족하는지 판정
 */
type CheckArrayTypes<T extends any[], Texpected> = T extends
    [infer First, ...infer Rest]
    ? First extends Texpected ? First : CheckArrayTypes<Rest, Texpected>
    : never;
/*
 * Record 내의 모든 타입이 Texpected를 만족하는지 판정
 */
type CheckRecordTypes<T extends Record<string, any>, Texpected> = {
    [Tprops in keyof T as T[Tprops] extends Texpected ? Tprops : never]:
    T[Tprops];
};
