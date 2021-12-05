export function sortOnInputDates(arr, start, end) { //21.09.2021
    return arr.filter(el => el.date.split(".")[2] >= start &&  el.date.split(".")[2] < end + 1)
} 