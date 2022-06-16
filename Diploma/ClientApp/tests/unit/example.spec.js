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

  it('renders props.description when passed', () => {
    const description = 'Descr'
    const wrapper = shallowMount(ProductCard, {
      props: { description }
    })
    expect(wrapper.text()).toMatch(name)
  })

  it('renders props.cost when passed', () => {
    const description = 'Cost'
    const wrapper = shallowMount(ProductCard, {
      props: { cost }
    })
    expect(wrapper.text()).toMatch(name)
  })
})
