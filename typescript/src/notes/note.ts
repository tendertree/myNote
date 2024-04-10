/*
 *   type
 */
//nameing should be explicity 
let d = 0 //x 
let damagaAmount = 0 //O 

//get data from parameter correctly 
function getEmail(email: { name: string, age: number }) { }
//function getEmailWrong({ name: string, age: number }) { } //x 
function getEmailTwo({ name, age }: { name: string, age: number }) { }


//generic limit  -- extend can limit generic type
interface TypeWithLength { length: number; }
function getOnlyHasLengthProperty<T extends TypeWithLength>(arg: T): number { return 1 }

const genericOccurError = <T>(arg: T): T[] => { return new Array(3) }
const genericOccurNoError = <T extends {}>(arg: T): T[] => { return new Array(3) }

//specify index type 
const combileTuple: [number, string?, ...number[]] = [0, "hi", 1, 2];

type Person = { name: string, age: number }
type manager = { grade: number }
type Example = { number: number, name: string, join: boolean }
//type use cases
type MarketManager = Person & manager
type PersonOrManager = Person | manager
type OneOfManager = Person[keyof Person] //name or age 

type Subset<T> = { [K in keyof T]?: T[K] }

//mapped type example
const MappedExample = {
    sheetBox: "box",
    sheetCard: "card"
}
export type MappedExampleTyep = keyof typeof MappedExample
//generated list by mapped type 
type StoredType = {
    [index in MappedExampleTyep as '${index}_MapType']: {
        arg?: any;
        isOpenned: boolean
    }
}

//literal type
type Area = "seoul" | "busan" | "daegu"
type currentArea = '${Area}-city' //seoul-city ..



const PersonKim: Subset<Example> = { name: "hello" };

//type checking
const Person = { name: "kim", age: 23 }
const getPersonValue = typeof Person // object
type getPersonType = typeof Person // person

const getEmailValue = typeof getEmail // function
type getEmailType = typeof getEmail //(email: { name: string, age: number }) => void

/*
 *  Type expansion
 */
//to expansion type and interface
interface Base {
    itemsName: string
}
interface BaseExpansion extends Base {
    count: number
}

type BaseType = {
    itemsName: string
}
type BaseExpansionType = { count: number; } & BaseType


type IdType = string | number;
type Numeric = number | boolean;

type Universal = IdType & Numeric //only numebr & number possible 

//in detcet whether type has specify properties
function useInCondition(props: any) {
    if ("number" in props) return
}


/*
 *  Type Guard
 */
type TextError = {
    Type: "Text";
    Code: string;
    msg: string;
}
type AlertError = {
    Type: "Alert";
    Code: string;
    ToastTime: () => void;
}

type ErrorTypes = TextError | AlertError
/*
 * basic type
 */
//enum
const enum EnumNumber { one = 1, two = 2 }
const myEnumNumber: EnumNumber = 2;


const bigNumber1: bigint = BigInt(999999999999);
const Normalnumber1: number = 3232;
//number1+bigNumber1 (x) 

const MUSIC_TITLE = Symbol("title"); //unique value
console.log(Symbol("title") === MUSIC_TITLE); // false

interface UnitTypeA {
    value: "a" //unit type
}
interface UnitTypeB {
    value: string//unit type
}
type Unions = UnitTypeA


//ever eles condition case 
//
type priceSameple = "1000" | "2000"

const checkTheOthersCases = (param: never) => {
    throw new Error("never type")
}

const checkTypeCondition = (type: priceSameple) => {
    if (type === "1000") { }
    else {
        //checkTheOthersCases(type); //if want to force to check all type case enable this line
        return "errors";
    }

}

/*
 *  loop
 */
//return first if it possible
function rightLoopCondition(person: { age: number }) {
    if (person.age == 10) return;
}
/*
 * Collection method
 */
interface Item {
    name: string;
}
const items: Item[] = [
    { name: "key" },
    { name: "key2" }
]
const hasKey: boolean = items.some(item => item.name === "key")
/*
 *  seperation
 *
 */

//use di than swtich 
interface Shape {
    area(): number
}

class Circle implements Shape {
    area() {
        return 0
    }
}

class Nemo implements Shape {
    area() {
        return 0
    }
}
// when you use interface, you don't need to use if condition , just use DI
function ShowArea(shape: Shape) {
    if (shape instanceof Circle) {
        return shape.area();
    } else if (shape instanceof Nemo) {
        return shape.area();
    }
}

function ShowAraeCorrectly(shape: Shape) {
    shape.area();
}

//use Map 
enum ShapeType {
    Circle,
    Nemo
}

const Shapes: { [key in ShapeType]: Shape } = {
    [ShapeType.Circle]: new Circle(),
    [ShapeType.Nemo]: new Nemo(),
}

const circleArea = Shapes[ShapeType.Circle].area();


/*
 * pattern
 *
 */
/*
 * policy pattern
 */
type Grade = {
    amount: number,
    spendTime: number

}
function isGoldMember(grade: Grade) {
    if (100 < grade.amount) {
        if (20 < grade.spendTime) {
        }
    }
}

function isSilverMember(grade: Grade) {
    if (50 < grade.amount) {
        if (10 < grade.spendTime) {
        }
    }
}


//정책패턴을 도입하면 판정 로직을 조금더 효율적으로 사용할 수 있다
//made type of "rule"
interface MemberRule {
    ok: () => boolean
}
class GoldMemberRule implements MemberRule {
    ok() {
        return true;
    }
}
class SilverMemberRule implements MemberRule {
    ok() {
        return true;
    }
}

class determindMeberGradeByPolicypattern {
    private readonly rules: Set<MemberRule>;
    constructor() {
        this.rules = new Set<MemberRule>();
        this.rules.add(new GoldMemberRule());
        this.rules.add(new SilverMemberRule());
    }
    complyWithAll(grade: Grade): boolean {
        //to get wrapped function, use values()
        for (const rule of this.rules.values()) {
            if (!rule.ok()) {
                return false;
            }
        }
        return true;
    }

}


/*
 *  preventing mutation
 */
//use slice when return inner list
class Member {
    // Define properties and methods of Member class
}

class Membership {
    private MemberShipmembers: Member[];

    constructor() {
        // Initialize members array
        this.MemberShipmembers = [];
    }

    // Method to retrieve members
    members(): ReadonlyArray<Member> {
        return this.MemberShipmembers.slice(); // Returns a copy of the members array
    }
}

/*
 * Type extend
 */

interface ISchoolLetter {
    address: string
}
interface ICompanyLetter {
    address: string
}
type MailMethod<T> = T extends "ICompanyLetter" ? ICompanyLetter : ISchoolLetter

//infer
type UnpackPromise<T> = T extends Promise<infer K>[] ? K : any;


export interface SubMenu {
    name: string;
    path: string;
}
export interface MainMenu {
    name: string;
    path?: string;
    subMenu?: SubMenu[];
}

export interface MainMenu {
    subMenus?: ReadonlyArray<SubMenu>;
}
export type MenuItem = MainMenu | SubMenu;
export const MenuList: MenuItem[] = [
    {
        name: "계정",
        subMenus: [
            {
                name: "기기 관리",
                path: "/device"
            }
        ]
    }
]
export const menuList = [] as const
type UnpackMenuNames<T extends ReadonlyArray<MenuItem>> =
    T extends ReadonlyArray<infer U> ?
    U extends MainMenu ?
    U["subMenus"] extends infer V ?
    V extends ReadonlyArray<SubMenu> ?
    UnpackMenuNames<V> : U["name"] : never
    : U extends SubMenu ? U["name"] : never : never;

//type template
type HeadNumber = 1 | 2 | 3 | 4;
type HeaderTag = 'h${HeadNumber}'
