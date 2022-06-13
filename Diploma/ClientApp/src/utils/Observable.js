/**
 * Утилитарный класс для имплементации наблюдателей и подписчиков
 */
class Observable {
  #observers = []
  #name = ""

  constructor(name) {
    this.#name = name
  }

  /**
   * Добавить наблюдателя за событием
   * @this Observable
   * @param {Function} observer Ф-ция, которая будет вызвана после срабатывания события
   * @return {Function} Ф-ция отписки
   */
  subscribe(observer) {
    console.log(`Добавление наблюдателя для события ${this.#name}`)
    this.#observers.push(observer)
    return () => this.#observers.splice(this.#observers.indexOf(observer), 1)
  }

  /**
   * Стригерить событие
   * @this Observable
   * @param {any} args Параметры, которые будут переданы подписчикам
   */
  fire(...args) {
    console.log(`Триггер события ${this.#name}`)
    for (const observer of this.#observers) {
      observer(...args)
    }
  }
}

export default Observable;
