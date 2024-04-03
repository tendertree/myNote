from urllib.parse import parse_qs
#get bytes or str -> bytes
def to_str(input):
    if isinstance(input,bytes):
        value = input.decode("utf-8")
    else:
        value = input
    return value

# print text value by format 
def print_formatted_text(key,value):
    formatted= '{} = {}'.format(key, value)
    formatted_interpolation= f'{key} = {value}'
    print(formatted)
    print(formatted_interpolation)

# parsing query 
def read_query_string():
    value = parse_qs('name=kim&age=5&home=',keep_blank_values=True)
    getbyDefaultValue = value.get('name',[''])[0] or 0


def read_query_string_by_default_value(values, key, default=0):
    # if key is none(empty) it return 0 
    found = values.get(key,['']) 
    if found[0]:
        return int(found[0])
    return default


## list
def read_two_list_at_once(names,ages):
    for name, count in zip(names, ages):
        print(name, count)


## Condition
def use_temp_value():
    if (count:=4) >=4:
        print("is four")
    else:
        print("count is not four")

## String 

