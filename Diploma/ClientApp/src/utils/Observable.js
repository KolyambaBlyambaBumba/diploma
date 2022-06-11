class Observable {
  #observers = []
  #name = ""

  constructor(name) {
    this.#name = name
  }


  subscribe(observer) {
    console.log(`Добавление наблюдателя для события ${this.#name}`)
    this.#observers.push(observer)
    return () => this.#observers.splice(this.#observers.indexOf(observer), 1)
  }

  fire(...args) {
    console.log(`Триггер события ${this.#name}`)
    for (const observer of this.#observers) {
      observer(...args)
    }
  }
}

export default Observable;
