export function SecondsAgo(data: Date) {
  let date = new Date(data);
  let currentDate = new Date();

  let days = Math.floor((currentDate.getTime() - date.getTime()) / 1000);
  return days;
}

export function ArrayLimit(arr: any[], c: number) {
  return arr.filter((x, i) => {
    return i <= c - 1;
  });
}

export function ArraySkip(arr: any[], c: number) {
  return arr.filter((x, i) => {
    return i > c - 1;
  });
}
