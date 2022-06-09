import s123 from '@/assets/s123.png'

const products = [
  {
    id: '1',
    image: s123,
    name: 'Букет',
    description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit quo autem ut.',
    cost: 250
  },
  {
    id: '2',
    image: s123,
    name: 'Букет 2',
    description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit quo autem ut.',
    cost: 3
  }
]

class ProductService {
  async getProducts () {
    return products
  }

  async getProductById (id) {
    return products.filter(x => x.id === id)[0]
  }
}

export default new ProductService()
