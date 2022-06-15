import { shallowMount } from '@vue/test-utils'
import ProductCard from '@/components/ProductCard.vue'

describe('ProductCard.vue', () => {
  it('renders props.name when passed', () => {
    const name = 'Product 1'
    const wrapper = shallowMount(ProductCard, {
      props: { name }
    })
    expect(wrapper.text()).toMatch(name)
  })
})
