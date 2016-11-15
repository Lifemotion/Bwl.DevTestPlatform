#define F_CPU 8000000
#define BAUD 9600
#define DEV_NAME "DevTestPlatform"

#include <avr/io.h>
#include <util/setbaud.h>
#include "libs/bwl_uart.h"
#include "libs/bwl_simplserial.h"
#include "libs/bwl_adc.h"
#include <avr/wdt.h>

#define ADC_ADJ ADC_ADJUST_RIGHT
#define ADC_REF ADC_REFS_INTERNAL
#define ADC_CLK ADC_PRESCALER_128

void sserial_send_start(){};

void sserial_send_end(){};

int adc_read_average(int count )
{
	unsigned long sum=0;
	for (int i=0; i<count; i++)
	{
		sum+=adc_read_once();
	}
	return sum/count;
}
#define sbi(port, bit)			(port) |=  (1 << (bit))
#define cbi(port, bit)			(port) &= ~(1 << (bit))
void sserial_process_request()
{
	if (sserial_request.command==10)
	{
		sserial_response.data[3]=PINB;
		sserial_response.data[4]=DDRB;
		sserial_response.data[5]=PORTB;
		
		sserial_response.data[6]=PINC;
		sserial_response.data[7]=DDRC;
		sserial_response.data[8]=PORTC;
		
		sserial_response.data[9]=PIND;
		sserial_response.data[10]=DDRD;
		sserial_response.data[11]=PORTD;
		
		sserial_response.result=0;
		sserial_response.datalength=12;
		sserial_send_response();
	}
	
	if (sserial_request.command==11)
	{	
		int val;
		cbi(PORTC,2);
		cbi(DDRC,2);
		adc_init(ADC_MUX_ADC2,ADC_ADJ,ADC_REF,ADC_CLK);	adc_read_once();
		val=adc_read_average(80);
		sserial_response.data[0]=val>>8;
		sserial_response.data[1]=val&255;	

		adc_init(ADC_MUX_ADC3,ADC_ADJ,ADC_REF,ADC_CLK);	adc_read_once();
		val=adc_read_average(80);
		sserial_response.data[2]=val>>8;
		sserial_response.data[3]=val&255;
		
		adc_init(ADC_MUX_ADC6,ADC_ADJ,ADC_REF,ADC_CLK);	adc_read_once();
		val=adc_read_average(80);
		sserial_response.data[4]=val>>8;
		sserial_response.data[5]=val&255;

		adc_init(ADC_MUX_ADC7,ADC_ADJ,ADC_REF,ADC_CLK);	adc_read_once();
		val=adc_read_average(80);
		sserial_response.data[6]=val>>8;
		sserial_response.data[7]=val&255;		
		
		sserial_response.result=0;
		sserial_response.datalength=8;
		sserial_send_response();
	}
	
	if (sserial_request.command==20)
	{
		DDRB=sserial_response.data[2];
		PORTB=sserial_response.data[3];		
		DDRC=sserial_response.data[4];
		PORTC=sserial_response.data[5];
		DDRD=sserial_response.data[6];
		PORTD=sserial_response.data[7];	
		
		sserial_response.result=0;
		sserial_response.datalength=0;
		sserial_send_response();		
	}
}

int main(void)
{
	sserial_find_bootloader();
	for (int i=0; i<16; i++)
	{
		if (sserial_devname[i]<30){sserial_devname[i]=' ';}
		sserial_devname[i+16]=DEV_NAME[i];
	}
	uart_init_withdivider(UBRR_VALUE);
	while(1)
	{
		sserial_poll_uart();
		wdt_reset();
	}
}