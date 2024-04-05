/*
 *   type
 */
const bigNumber1: bigint = BigInt(999999999999);
const number1: number = 3232;
//number1+bigNumber1 (x) 

const MUSIC_TITLE = Symbol("title"); //unique value
console.log(Symbol("title") === MUSIC_TITLE); // false

//nameing should be explicity 
let d = 0 //x 
let damagaAmount = 0 //O 

//get data from parameter correctly 
function getEmail(email: { name: string, age: number }) { }
//function getEmailWrong({ name: string, age: number }) { } //x 
function getEmailTwo({ name, age }: { name: string, age: number }) { }



//type checking
const Person = { name: "kim", age: 23 }
const getPersonValue = typeof Person // object
type getPersonType = typeof Person // person

const getEmailValue = typeof getEmail // function
type getEmailType = typeof getEmail //(email: { name: string, age: number }) => void

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
